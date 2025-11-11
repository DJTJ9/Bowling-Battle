using DependencyInjection;
using UnityEngine;

public class BallCamera : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 offset;
    
    [Inject] private BallMovement ballMovement;

    private void Update()
    {
        transform.position = ballMovement.transform.position + offset;
    }
}
