using UnityEngine;
using System.Collections;

public class PatternManager : MonoBehaviour
{
    // 패턴 prefabs
    public GameObject[] patterns = new GameObject[4];

    // 패턴 생성 배열 최대 3개 동시생성 가능
    GameObject[] pattern = new GameObject[3];

    public void PatternGenerate(int num, int number)
    {
        pattern[num] = Instantiate(patterns[number], transform.position, transform.rotation) as GameObject;
        pattern[num].transform.parent = transform;
    }

    public void PatternDelete(int num)
    {
        Destroy(pattern[num]);
    }

    /* 패턴 테스트
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            PatternGenerate(0, 0);
        }
        if (Input.GetKeyDown("2"))
        {
            PatternDelete(0);
        }
    }
    */
}
