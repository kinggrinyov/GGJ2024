using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    float damage = 7;

    [SerializeField]
    private float BulletLifetime = 5;
    private float timer = 0;
    private void OnTriggerEnter(Collider other)
    {
        //if player, deal damage
        Destroy(gameObject);
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= BulletLifetime)
            Destroy(gameObject);
    }
}
