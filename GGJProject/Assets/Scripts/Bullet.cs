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
    private ParticleSystem _explodePfx = null;

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


        _explodePfx.transform.SetParent(null);
        _explodePfx.Play();
        GameObject.Destroy(_explodePfx.gameObject, 2f);

        Destroy(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _gundata.LifeSpan)
            Destroy(gameObject);
    }


}
