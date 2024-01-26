using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody = null;
    GroundChecker _groundChecker = null;

    [field: SerializeField]
    public float MovementSpeed { get; private set; }
    [field: SerializeField]
    public float JumpSpeed { get; private set; }
    [field: SerializeField]
    public int JumpLimit { get; private set; }

    private int _jumpsLeft = 0;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        _groundChecker.OnGroundColliderEntered += ResetJumps;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateJumping();
    }

    private void UpdateMovement()
    {
        float inputX = Input.GetAxis("Horizontal");

        Vector3 originalVelocity = _rigidbody.velocity;

        Vector3 movementDelta = new Vector3(MovementSpeed * inputX, originalVelocity.y, 0);

        _rigidbody.velocity = movementDelta;
    }
    private void UpdateJumping()
    {
        if(Input.GetButtonDown("Jump"))
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
}
