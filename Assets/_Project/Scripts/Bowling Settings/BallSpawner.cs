using System;
using DependencyInjection;
using UnityEngine;

public class BallSpawner : MonoBehaviour, IDependencyProvider
{
    public GameObject CurrentBallInstance;
    
    public BowlingBallSO BallSO;

    [Provide] BallSpawner ProvideBallSpawner() => this;
    
    private void Awake()
    {
        CurrentBallInstance = GetComponentInChildren<BallMovement>().gameObject;
    }

    public void SpawnBall(BowlingBallSO ballSO)
    {
        if (CurrentBallInstance != null)
            Destroy(CurrentBallInstance);
        
        CurrentBallInstance = Instantiate(ballSO.ball, transform.position, transform.rotation);
        BallSO = ballSO;
    }
}
