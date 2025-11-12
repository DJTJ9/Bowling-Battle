using System;
using DependencyInjection;
using UnityEngine;

public class BallSpawner : MonoBehaviour, IDependencyProvider
{
    public GameObject CurrentBallInstance;

    [Provide] BallSpawner ProvideBallSpawner() => this;

    public void SpawnBall(BowlingBallSO ballSO)
    {
        if (CurrentBallInstance != null)
            Destroy(CurrentBallInstance);
        
        CurrentBallInstance = Instantiate(ballSO.ball, transform.position, transform.rotation);
    }
}
