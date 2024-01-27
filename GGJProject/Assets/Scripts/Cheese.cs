using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : Bullet
{
    private float _timer = 0;

    [SerializeField]
    private float tickrate = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }
        }

        if (other.TryGetComponent<Cheese>(out Cheese cheese))
        {
            if (cheese._ownerTransform == _ownerTransform)
            {
                return;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }
            else
            {
                _timer += Time.deltaTime;
                if (_timer > tickrate)
                {
                    player.TakeDamage(_gundata.damage);
                    _timer = 0;
                }
            }
        }
    }
}
