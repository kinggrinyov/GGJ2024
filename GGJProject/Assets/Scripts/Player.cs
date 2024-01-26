using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody = null;
    GroundChecker _groundChecker = null;

    [field: SerializeField]
    public GunData GunData { get; private set; }

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

    public Gun _currentGun = null;

    private float _currentHealth = 0;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _groundChecker.OnGroundColliderEntered += ResetJumps;

        _currentGun = new Gun(ShootTransform, GunData, transform);

        _currentHealth = MaximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        int inputX = Mathf.RoundToInt(Input.GetAxis(InputHorizontalAxisName));

        UpdateMovement(inputX);
        UpdateDirection(inputX);
        UpdateJumping();

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
            return;
        }
        
        Die();
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} Died");
        GameInstance.Instance.PlayerDied();
    }
}
