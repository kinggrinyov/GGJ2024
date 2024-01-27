using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class Gun
{
    private GunData _gunData = null;

    //guns' fire rate
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

        float segmentAngle = _gunData.ArcAngle / Mathf.Max(_gunData.ProjectileAmount - 1, 1);
        float startingAngle = _gunData.ArcAngle / 2;


        for (int i = 0; i < _gunData.ProjectileAmount;i++)
        {
            CreateandFireBullet(segmentAngle, startingAngle, i);
        }

        _firingCooldown = _gunData.ShootCooldown;
    }

    private void CreateandFireBullet(float arcAngle, float startAngle, int amount)
    {
        GameObject bulletGo = Object.Instantiate(_gunData.ProjectilePrefab, _shootTransform.position, Quaternion.identity);
        bulletGo.GetComponent<Bullet>().Init(_ownerTransform, _gunData);

        Vector3 bulletDirection = _shootTransform.forward;
        bulletDirection.z = 0;

        bulletDirection = Quaternion.AngleAxis(startAngle - (arcAngle * amount), _shootTransform.right) * bulletDirection;

        bulletDirection.Normalize();
        bulletGo.GetComponent<Rigidbody>().AddForce(bulletDirection * _gunData.ProjectileSpeed);
    }

    public void Update()
    {
        _firingCooldown -= Time.deltaTime;
    }
}
