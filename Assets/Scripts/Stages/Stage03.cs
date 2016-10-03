using UnityEngine;
using System.Collections;

public class Stage03 : MonoBehaviour
{
    TimeCount timeCount;
    PatternManager patternManager;
    PlanetColor planetColor;

    // 패턴 생성 삭제 단계
    bool[] phase = new bool[9];

    void Awake()
    {
        timeCount = GameObject.Find("Player").GetComponent<TimeCount>();
        patternManager = this.gameObject.GetComponent<PatternManager>();
        planetColor = this.gameObject.GetComponent<PlanetColor>();

        for (int i = 0; i < phase.Length; i++)
            phase[i] = false;

        planetColor.playTime = 60;

        StartCoroutine(UpdateByUsingCoroutine());
    }

    IEnumerator UpdateByUsingCoroutine()
    {
        while (true)
        {
            if (phase[0] == false && timeCount.timer > 3)
            {
                patternManager.PatternGenerate(0, 0);
                phase[0] = true;
            }
            else if (phase[1] == false && timeCount.timer > 57)
            {
                patternManager.PatternDelete(0);
                phase[1] = true;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
