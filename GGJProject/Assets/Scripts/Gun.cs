using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun
{
    private GunData _gunData = null;

    float _firingCooldown = 0;

    private Transform _shootTransform = null;   
    private Transform _ownerTransform = null;   

    public Gun(Transform shootTransform, GunData gunData, Transform playerTransform)
    {

        _ownerTransform = playerTransform;
        _shootTransform = shootTransform;
        _gunData = gunData;
    }

    public void Shoot()
    {
        if (_firingCooldown > 0)
        {
            return;
        }
        for (int i = 0; i < _gunData.ProjectileAmount; i++)
        {
            GameObject bulletGo = Object.Instantiate(_gunData.ProjectilePrefab, _shootTransform.position, Quaternion.identity);
            bulletGo.GetComponent<Bullet>().Init(_ownerTransform);

            Vector3 bulletDirection = _shootTransform.forward;
            bulletDirection.y = 0;
            bulletDirection.z = 0;
            bulletDirection.Normalize();
    
            bulletGo.GetComponent<Rigidbody>().AddForce(bulletDirection * _gunData.ProjectileSpeed);
        }
        _firingCooldown = _gunData.ShootCooldown;
    }

    public void Update()
    {
        _firingCooldown -= Time.deltaTime;
    }
}
