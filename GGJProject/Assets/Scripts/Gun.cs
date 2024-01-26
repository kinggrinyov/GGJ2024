using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject ammo;

    [SerializeField]
    float bulletSpeed = 3000;

    [SerializeField]
    float fireRate = 2;

    float delayedfire = 0;
    void Update()
    {
        GameObject temp = null;
        if (Input.GetKey(KeyCode.X))
        {
            if (delayedfire <= 0)
            {
                temp = Object.Instantiate(ammo, this.transform);
                temp.GetComponent<Rigidbody>().AddForce(new Vector3(bulletSpeed, 0, 0));
                delayedfire = fireRate;
            }
        }
        delayedfire -= Time.deltaTime;
    }
}
