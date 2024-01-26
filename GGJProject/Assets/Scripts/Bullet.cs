using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField]
    float damage = 7;
    private void OnTriggerEnter(Collider other)
    {
        //if player, deal damage
        Destroy(gameObject);
        
    }
}
