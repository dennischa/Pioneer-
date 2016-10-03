using UnityEngine;
using System.Collections;

public class Stage01 : MonoBehaviour
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
            else if (phase[1] == false && timeCount.timer > 13)
            {
                patternManager.PatternDelete(0);
                phase[1] = true;
            }
            else if (phase[2] == false && timeCount.timer > 15)
            {
                patternManager.PatternGenerate(0, 1);
                phase[2] = true;
            }
            else if (phase[3] == false && timeCount.timer > 28)
            {
                patternManager.PatternDelete(0);
                phase[3] = true;
            }
            else if (phase[4] == false && timeCount.timer > 30)
            {
                patternManager.PatternGenerate(0, 2);
                phase[4] = true;
            }
            else if (phase[5] == false && timeCount.timer > 43)
            {
                patternManager.PatternDelete(0);
                phase[5] = true;
            }
            else if (phase[6] == false && timeCount.timer > 45)
            {
                patternManager.PatternGenerate(0, 3);
                phase[6] = true;
            }
            else if (phase[7] == false && timeCount.timer > 55)
            {
                patternManager.PatternGenerate(1, 2);
                phase[7] = true;
            }
            else if (phase[8] == false && timeCount.timer > 59)
            {
                patternManager.PatternDelete(0);
                patternManager.PatternDelete(1);
                phase[8] = true;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
