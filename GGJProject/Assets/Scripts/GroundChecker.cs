using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundChecker : MonoBehaviour
{
    public Action OnGroundColliderEntered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Ground")
        {
            return;
        }


        OnGroundColliderEntered?.Invoke();
    }
}
