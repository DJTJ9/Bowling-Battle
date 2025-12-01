using UnityEngine;

[RequireComponent (typeof(GroundChecker))]
public class RigidbodyMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float shootForce;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpSpeedModifier = 1;
    [SerializeField] private float fallSpeedModifier = 1;

    private new Transform transform;
    private new Rigidbody rigidbody;
    private GroundChecker groundChecker;

    private Vector3 moveDirection;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
        groundChecker = GetComponent<GroundChecker>();
    }

    private void FixedUpdate()
    {
        UpdateHorizontalMovement();
        UpdateVerticalMovement();
    }

    /// <summary>
    /// Recieves a move direction
    /// </summary>
    public void Move(Vector3 _direction)
    {
        moveDirection = _direction;
    }

    public void Jump()
    {
        if (groundChecker.isGrounded)
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    
    public void Shoot()
    {
        Camera cam = Camera.main;

        // Ray aus Bildschirmmitte
        Ray ray = cam.ScreenPointToRay(
            new Vector3(Screen.width / 2f, Screen.height / 2f, 0f)
        );

        Vector3 targetPoint;

        // Raycast um Zielpunkt zu finden
        if (Physics.Raycast(ray, out RaycastHit hit, 500f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(500f);
        }

        // Richtung vom Rigidbody zum Ziel
        Vector3 direction = (targetPoint - rigidbody.transform.position).normalized;

        // AddForce
        rigidbody.AddForce(direction * shootForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Collects the current Velocity of the rigidbody and sets the speed
    /// Transforms moving direction from local space to world space
    /// Collects the speed difference to target velocity and clamps the max velocity
    /// Sets force mode to VelocityChange
    /// </summary>
    public void UpdateHorizontalMovement()
    {
        Vector3 currentVelocity = rigidbody.linearVelocity;
        Vector3 targetVelocity = new Vector3(moveDirection.x, 0f , moveDirection.z);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = targetVelocity - currentVelocity;
        velocityChange = new Vector3(velocityChange.x, 0f, velocityChange.z);
        velocityChange = Vector3.ClampMagnitude(velocityChange, maxSpeed);

        rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Recieves the current rotation
    /// Sets the rotation to a target rotation
    /// </summary>
    public void RotateHorizontal(float _rotation)
    {
        var currentRotation = rigidbody.rotation.eulerAngles;
        var targetRotation = currentRotation + new Vector3(0f, _rotation, 0f);
        rigidbody.rotation = Quaternion.Euler(targetRotation);
    }

    /// <summary>
    /// Modifies jump and fall speed
    /// </summary>
    private void UpdateVerticalMovement()
    {
        if (rigidbody.linearVelocity.y < 0)
            rigidbody.linearVelocity += Vector3.up * (Physics.gravity.y * (fallSpeedModifier - 1) * Time.fixedDeltaTime);

        if (rigidbody.linearVelocity.y > 0)
            rigidbody.linearVelocity += Vector3.up * (Physics.gravity.y * jumpSpeedModifier * Time.fixedDeltaTime);
    }
}
