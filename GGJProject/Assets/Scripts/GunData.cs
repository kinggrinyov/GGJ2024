using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "ScriptableObjects/GunData")]
public class GunData : ScriptableObject
{
    [field: SerializeField]
    public GameObject ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float ProjectileSpeed { get; private set; }

    [field: SerializeField]
    public float ShootCooldown { get; private set; }
}
