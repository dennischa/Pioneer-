using UnityEngine;
using System.Collections;

public class PatternOfRandomCircle : PatternSetting
{
    public IEnumerator Start()
    {
        bullet.shotSpeed = 3f;
        bullet.aliveTime = 4f;
        shotCount = 3f;
        shotDelay = 0.015f;

        while (true)
        {
            for (int i = 0; i < shotCount; i++)
                Instantiate(bullet, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));

            yield return new WaitForSeconds(shotDelay);
        }
    }
}
