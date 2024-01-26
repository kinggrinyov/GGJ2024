using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundChecker : MonoBehaviour
{
    public Action OnGroundColliderEntered;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.transform.name}");

        OnGroundColliderEntered?.Invoke();
    }
}
