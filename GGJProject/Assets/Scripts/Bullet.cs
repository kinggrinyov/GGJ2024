using System;
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

    private Transform _ownerTransform;

    public void Init(Transform ownerTransform)
    {
        _ownerTransform = ownerTransform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }
            player.TakeDamage(damage);
        }
        
        if (other.TryGetComponent<Bullet>(out Bullet bullet))
        {
            if (bullet._ownerTransform == _ownerTransform)
            {
                return;
            }
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= BulletLifetime)
            Destroy(gameObject);
    }
}
