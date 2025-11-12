using DependencyInjection;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 offset;
    
    // [Inject] private BallMovement ballMovement;
    [Inject] private BallSpawner ballSpawner;

    private void Update()
    {
        if (ballSpawner.CurrentBallInstance == null) return;
        transform.position = ballSpawner.CurrentBallInstance.transform.position + offset;
    }
}
