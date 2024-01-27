using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class Gun
{
    public GunData GunData { get; private set; } = null;


    float _firingCooldown = 0;

    private Transform _shootTransform = null;   
    private Transform _ownerTransform = null;

    public int CurrentAmmo { get; private set; }

    private float _reloadTimer = 0;

    public bool IsReloading => _reloadTimer > 0;

    public Gun(Transform shootTransform, GunData gunData, Transform playerTransform)
    {
        _ownerTransform = playerTransform;
        _shootTransform = shootTransform;
        GunData = gunData;
        CurrentAmmo = GunData.maxAmmo;
    }

    public void Shoot()
    {
        if(_reloadTimer > 0)
        {
            return;
        }

        if (_firingCooldown > 0)
        {
            return;
        }

        if(CurrentAmmo <= 0)
        {
            Reload();
            return;
        }

        float segmentAngle = GunData.ArcAngle / Mathf.Max(GunData.ProjectileAmount - 1, 1);
        float startingAngle = GunData.ArcAngle / 2;


        for (int i = 0; i < GunData.ProjectileAmount;i++)
        {
            CreateandFireBullet(segmentAngle, startingAngle, i);
        }

        _firingCooldown = GunData.ShootCooldown;
    }

    private void CreateandFireBullet(float arcAngle, float startAngle, int amount)
    {
        GameObject bulletGo = Object.Instantiate(GunData.ProjectilePrefab, _shootTransform.position, Quaternion.identity);
        bulletGo.GetComponent<Bullet>().Init(_ownerTransform, GunData);

        Vector3 bulletDirection = _shootTransform.forward;
        bulletDirection.z = 0;

        bulletDirection = Quaternion.AngleAxis(startAngle - (arcAngle * amount), _shootTransform.right) * bulletDirection;

        bulletDirection.Normalize();
        bulletGo.GetComponent<Rigidbody>().AddForce(bulletDirection * GunData.ProjectileSpeed);
        CurrentAmmo--;
    }

    public void Update()
    {
        _firingCooldown -= Time.deltaTime;

        if(_reloadTimer > 0)
        {
            _reloadTimer -= Time.deltaTime;
            if(_reloadTimer <= 0)
            {
                CurrentAmmo = GunData.maxAmmo;
            }
        }
    }

    public void Reload()
    {
        _reloadTimer = GunData.ReloadDuration;
    }
}
