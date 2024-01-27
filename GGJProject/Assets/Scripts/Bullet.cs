using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected GunData _gundata = null;   
    
    protected float timer = 0;

    protected Transform _ownerTransform;

    [SerializeField]
    protected GameObject _effect;
    public void Init(Transform ownerTransform, GunData gundata)
    {
        _ownerTransform = ownerTransform;
        _gundata = gundata;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }
            player.TakeDamage(_gundata.damage);
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
        if (timer >= _gundata.LifeSpan)
            Destroy(gameObject);
    }
}
