using UnityEngine;
using System.Collections;

public class PatternOfBidirectionalSpiral : PatternSetting
{
    public IEnumerator Start()
    {
        bullet.shotSpeed = 2f;
        bullet.aliveTime = 4f;
        shotAngle = 0f;
        float angle = 180f;
        shotAngleRate = 6f;
        float rate = -4;
        shotCount = 3f;
        shotDelay = 0.03f;

        while (true)
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < shotCount; i++)
                {
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, shotAngle - (360 / shotCount) * i, 0));
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, angle - (360 / shotCount) * i, 0));
                }
            }
            shotAngle += shotAngleRate;
            angle += rate;


            yield return new WaitForSeconds(shotDelay);
        }
    }
}