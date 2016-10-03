using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // Bullet Speed
    public float shotSpeed;
    public float aliveTime;

    float rotate;

    void Start()
    {
        rotate = Random.Range(3, 6);

        GetComponent<Rigidbody>().velocity = transform.forward * shotSpeed;
        
        // 총알 생존 시간
        Destroy(gameObject, aliveTime);
    }
}
