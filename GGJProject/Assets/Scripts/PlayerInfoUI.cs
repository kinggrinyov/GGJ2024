using TMPro;
using UnityEngine;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private TextMeshProUGUI _weaponText;
    [SerializeField]
    private TextMeshProUGUI _ammoText;
    [SerializeField]
    private TextMeshProUGUI _healthText;

    private void Update()
    {
        _weaponText.text = "Weapon: " + _player._currentGun.GunData.DisplayName;
        
        _ammoText.text = "Ammo: " + (_player._currentGun.IsReloading ? "Reloading" : _player._currentGun.CurrentAmmo);

        _healthText.text = $"Health: {_player.CurrentHealth}";
    }
}
