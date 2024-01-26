using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody = null;

    [field: SerializeField]
    public float MovementSpeed { get; private set; }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 originalVelocity = _rigidbody.velocity;

        Vector3 movementDelta = new Vector3(MovementSpeed * inputX, originalVelocity.y, originalVelocity.z);

        _rigidbody.velocity = movementDelta;
    }
}
