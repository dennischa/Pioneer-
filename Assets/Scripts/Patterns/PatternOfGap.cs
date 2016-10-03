using UnityEngine;
using System.Collections;

public class PatternOfGap : PatternSetting
{
    public IEnumerator Start()
    {
        bullet.shotSpeed = 1f;
        bullet.aliveTime = 9f;
        shotDelay = 1.5f;

        float[] randAngle = new float[3];
        int i;

        while (true)
        {
            randAngle[0] = Random.Range(0, 100);
            randAngle[1] = Random.Range(120, 220);
            randAngle[2] = Random.Range(240, 340);
            for (i = 0; i < 360; i+=4)
            {
                if (randAngle[0] < i && i < randAngle[0] + 20)
                    continue;
                if (randAngle[1] < i && i < randAngle[1] + 20)
                    continue;
                if (randAngle[2] < i && i < randAngle[2] + 20)
                    continue;
                Instantiate(bullet, transform.position, Quaternion.Euler(0, i, 0));
            }

            shotDelay -= 0.01f;

            yield return new WaitForSeconds(shotDelay);
        }
    }
}
