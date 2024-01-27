using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Trap : Bullet
{
    [SerializeField]
    private ParticleSystem _explosionPfx = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (player.transform == _ownerTransform)
            {
                return;
            }

            Explode(player);
        }

        if (other.gameObject.TryGetComponent<Trap>(out Trap trap))
        {
            if (trap._ownerTransform == _ownerTransform)
            {
                return;
            }

            Explode(null);
        }
    }

    private void Explode(Player player)
    {
        if(player != null)
        {
            player.TakeDamage(_gundata.damage);
        }

        _explosionPfx.transform.SetParent(null);
        _explosionPfx.Play();

        Destroy(gameObject);
    }
}
