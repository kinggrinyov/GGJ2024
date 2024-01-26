using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [field: SerializeField]
    public Transform TargetToFollow { get; private set; }

    [field: SerializeField]
    public Vector3 CameraOffset { get; private set; }

    [field: SerializeField]
    public float CameraSpeed { get; private set; }


    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, TargetToFollow.position + CameraOffset, Time.deltaTime * CameraSpeed);
    }
}
