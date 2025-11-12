using System;
using DependencyInjection;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController), typeof(PlayerInput), typeof(Rigidbody))]
public class BallMovement : MonoBehaviour, IDependencyProvider
{
    [Header("Input")]
    private Vector2 moveInput;
    private bool jumpInput;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    private InputAction moveInputAction;
    private InputAction jumpInputAction;

    [Header("References")]
    private CharacterController controller;
    private PlayerInput playerInput;
    private Rigidbody rb;
    
    [Provide]
   BallMovement ProvideBallMovement()
    {
        return this;
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerInput.enabled = true;
        
        GameStartConfiguration();
    }

    void FixedUpdate()
    {
        if (controller.enabled) Movement();
    }

    public void GameStartConfiguration()
    {
        MapInputActions();
        ResetComponents();
        SetCameraForPlayerInput();
    }
    
    private void Movement()
    {
        StartPositionMovement();
    }

    private void StartPositionMovement()
    {
        GetMoveDirection();
        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0);

        move *= moveSpeed;
        
        controller.Move(move * Time.deltaTime);
    }

    private void GetMoveDirection()
    {
        moveInput = moveInputAction.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            controller.enabled = false;
            rb.freezeRotation = false;
            rb.useGravity = true;
            moveInput = Vector2.zero;
            rb.linearVelocity = Vector3.zero;
        }
    }
    
    private void MapInputActions() 
    {
        moveInputAction = playerInput.actions["Move"];

        jumpInputAction = playerInput.actions["Jump"];
        jumpInputAction.started += OnJump;
    }

    private void ResetComponents()
    {
        controller.enabled = true;
        playerInput.enabled = true;
        rb.freezeRotation = true;
        rb.useGravity = false;
    }
    
    private void SetCameraForPlayerInput()
    {
        playerInput.camera = Camera.main;
    }
}
