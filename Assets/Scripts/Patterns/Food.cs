using UnityEngine;
using System.Collections;

public class Food : PatternSetting
{
    public Bullet bullet;

    public IEnumerator Start()
    {
        bullet.shotSpeed = 3f;
        shotDelay = 1f;

        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));

            yield return new WaitForSeconds(shotDelay);
        }
    }
}
