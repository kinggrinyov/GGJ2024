using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunData")]
public class GunData : ScriptableObject
{
    [field: SerializeField]
    public string DisplayName { get; private set; }

    [field: SerializeField]
    public GameObject ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float ProjectileSpeed { get; private set; }

    [field: SerializeField]
    public float ShootCooldown { get; private set; }

    [field: SerializeField]
    public int ProjectileAmount { get; private set; }

    [field: SerializeField]
    public float ArcAngle { get; private set; }
    [field: SerializeField]
    public float damage { get; private set; }
    [field:SerializeField]
    public float LifeSpan {  get; private set; }

    [field:SerializeField]
    public int maxAmmo { get; private set; }

    [field: SerializeField]
    public float ReloadDuration { get; private set; }
}
