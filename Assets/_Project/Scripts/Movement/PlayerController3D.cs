using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3D : MonoBehaviour
{
    [Header("Input")]
    private Vector2 moveInput;
    private float turnInput;
    private bool jumpInput;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float sprintTransitSpeed = 5f;
    [SerializeField] private float turningSpeed = 2f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = 9.81f;
    
    private float verticalVelocity;
    private float speed;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    private CharacterController controller;
    private PlayerInput playerInput;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
        Turn();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        move = cameraTransform.transform.TransformDirection(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = Mathf.Lerp(speed, runSpeed, sprintTransitSpeed * Time.deltaTime);;
        }
        else
        {
            speed = Mathf.Lerp(speed, walkSpeed, sprintTransitSpeed * Time.deltaTime);;
        }

        move *= speed;
        
        move.y = VerticalForceCalculation();
        
        controller.Move(move * Time.deltaTime);
    }

    private void Turn()
    {
            Vector3 currentLookDirection = controller.velocity.normalized;
            currentLookDirection.y = 0f;
            
            currentLookDirection.Normalize();
            
            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);
    }

    private float VerticalForceCalculation()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
            
            if (jumpInput)
            {
                verticalVelocity = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            jumpInput = false;
        }
        return verticalVelocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
        }
        else if (context.canceled)
        {
            jumpInput = false;
        }
    }
}
