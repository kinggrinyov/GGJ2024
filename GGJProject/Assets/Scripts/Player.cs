using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody = null;
    GroundChecker _groundChecker = null;

    [field:SerializeField]
    public GunData[] guns;
    private Gun[] initializedGuns;
    int AmountOfGuns = 0;
    int CurrentGun = 0;

    [field: SerializeField]
    public Transform ShootTransform { get; private set; }

    [field: SerializeField]
    public float MovementSpeed { get; private set; }
    [field: SerializeField]
    public float JumpSpeed { get; private set; }
    [field: SerializeField]
    public int JumpLimit { get; private set; }
    [field: SerializeField]
    public float FastFallSpeed { get; private set; }
    [field: SerializeField]
    public float MaximumHealth { get; private set; }

    private int _jumpsLeft = 0;

    [field: SerializeField]
    public string InputHorizontalAxisName { get; private set; } = "Horizontal";
    [field: SerializeField]
    public string InputJumpName { get; private set; } = "Jump";
    [field: SerializeField]
    public string InputShootGunName { get; private set; } = "Fire1";

    [field: SerializeField]
    public string InputFastFallName { get; private set; } = "FastFall";

    [field: SerializeField]
    public string InputChangeWeapon { get; private set; } = "SwapWep";

    [field:SerializeField]
    public Gun _currentGun = null;

    private float _currentHealth = 0;

    private Renderer _playerRenderer = null;

    private bool _damageBool = false;

    private Color _playerColor;
    private float DamageDuration = 0.1f;

    private float _damageTime = 0;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _groundChecker.OnGroundColliderEntered += ResetJumps;

        _currentHealth = MaximumHealth;

        _playerRenderer = this.GetComponentInChildren<Renderer>();

        _playerColor = _playerRenderer.material.color;

        AmountOfGuns = guns.Length;

        initializedGuns = new Gun[AmountOfGuns];
        for (int i = 0; i < AmountOfGuns; i++)
        {
            initializedGuns[i] = new Gun(ShootTransform, guns[i], transform);
        }
        _currentGun = initializedGuns[0];
    }

    // Update is called once per frame
    void Update()
    {
        int inputX = Mathf.RoundToInt(Input.GetAxis(InputHorizontalAxisName));

        UpdateMovement(inputX);
        UpdateDirection(inputX);
        UpdateJumping();

        changeWeapons();

        if(Input.GetButtonDown(InputFastFallName))
        {
            Vector3 originalVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector3(originalVelocity.x, -FastFallSpeed, 0);
        }

        _currentGun.Update();

        if (Input.GetButtonDown(InputShootGunName))
        {
            _currentGun.Shoot();
        }

        if (_damageBool)
        {
            _damageTime += Time.deltaTime;
            if (_damageTime > DamageDuration)
            {
                Debug.Log("change color back");
                _playerRenderer.material.SetColor("_Color", _playerColor);
                _damageBool = false;
                _damageTime = 0;
            }
        }
    }

    void changeWeapons() 
    {
        if (Input.GetButtonDown(InputChangeWeapon))
        {
            if(AmountOfGuns-1 > CurrentGun)
            { 
                _currentGun = initializedGuns[CurrentGun + 1];
                CurrentGun++;
                Debug.Log("swap to " + CurrentGun);
            }
            else if(AmountOfGuns-1 <= CurrentGun)
            {
                CurrentGun = 0;
                _currentGun = initializedGuns[CurrentGun];
            }
        }
    }

    private void UpdateMovement(int inputX)
    {
        Vector3 originalVelocity = _rigidbody.velocity;

        Vector3 movementDelta = new Vector3(MovementSpeed * inputX, originalVelocity.y, 0);

        _rigidbody.velocity = movementDelta;
    }

    private void UpdateJumping()
    {
        if(Input.GetButtonDown(InputJumpName))
        {
            if(_jumpsLeft == 0)
            {
                return;
            }

            _jumpsLeft--;

            Vector3 originalVelocity = _rigidbody.velocity;

            _rigidbody.velocity = new Vector3(originalVelocity.x, JumpSpeed, 0);
        }
    }

    private void ResetJumps()
    {
        _jumpsLeft = JumpLimit;
    }

    private void UpdateDirection(int inputX)
    {
        int direction = inputX;
        if (direction != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, direction == 1 ? 0 : -180, 0));
        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log($"{gameObject.name} Took {damage} Damage");

        _currentHealth -= damage;

        if(_currentHealth > 0)
        {
            _damageBool = true;
            _playerRenderer.material.SetColor("_Color", Color.grey);

            return;
        }
        
        Die();
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} Died");
        GameInstance.Instance.PlayerDied(gameObject.name);
    }
}
