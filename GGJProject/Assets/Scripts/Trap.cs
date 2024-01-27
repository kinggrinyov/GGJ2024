using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Bullet
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }
            player.TakeDamage(_gundata.damage);
            Destroy(gameObject);
        }

        if (other.gameObject.TryGetComponent<Trap>(out Trap trap))
        {
            if (trap._ownerTransform == _ownerTransform)
            {
                return;
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= _gundata.LifeSpan)
            Destroy(gameObject);
    }
}