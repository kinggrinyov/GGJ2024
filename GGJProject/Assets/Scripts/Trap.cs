using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Trap : Bullet
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
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
}
