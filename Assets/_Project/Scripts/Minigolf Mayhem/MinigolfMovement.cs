using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigolfMovement : MonoBehaviour
{
    [SerializeField] private float force = 20f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    
    private InputAction moveInputAction;
    private InputAction shootInputAction;
    private InputAction lookInputAction;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void Shoot()
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
        Vector3 direction = (targetPoint - rb.transform.position).normalized;

        // AddForce
        rb.AddForce(direction * force, ForceMode.Impulse);
    }
    
    private void MapInputActions() {
        moveInputAction = playerInput.actions["Move"];

        shootInputAction = playerInput.actions["Jump"];
        shootInputAction.started += OnShootInput;

        lookInputAction = playerInput.actions["Look"];
    }

    private void OnShootInput(InputAction.CallbackContext _context)
    {
        if (_context.phase == InputActionPhase.Started)
        {
            Shoot();
        }
    }
}
