using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun
{
    private GunData _gunData = null;

    float _firingCooldown = 0;

    private Transform _shootTransform = null;   

    public Gun(Transform shootTransform, GunData gunData)
    {
        _shootTransform = shootTransform;
        _gunData = gunData;
    }

    public void Shoot()
    {
        if (_firingCooldown > 0)
        {
            return;
        }

        GameObject bulletGo = Object.Instantiate(_gunData.ProjectilePrefab, _shootTransform.position, Quaternion.identity);

        bulletGo.GetComponent<Rigidbody>().AddForce(new Vector3(_gunData.ProjectileSpeed, 0, 0));

        _firingCooldown = _gunData.ShootCooldown;
    }

    public void Update()
    {
        _firingCooldown -= Time.deltaTime;
    }
}
