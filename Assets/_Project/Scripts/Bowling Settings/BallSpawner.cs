using System;
using DependencyInjection;
using UnityEngine;
using UnityEngine.Serialization;

public class BallSpawner : MonoBehaviour, IDependencyProvider
{
    public GameObject CurrentBallInstance { get; private set; }
    public BowlingBallSO CurrentBallSO { get; private set; }
    
    [SerializeField] private BowlingBallCollectionSO ballCollectionSO;

    [Provide] BallSpawner ProvideBallSpawner() => this;
    
    private void Awake()
    {
        CurrentBallInstance = Instantiate(ballCollectionSO.BowlingBalls[BallType.Basketball].ball,
            transform.position, transform.rotation);

        CurrentBallSO = ballCollectionSO.BowlingBalls[BallType.Basketball];
    }

    public void SpawnBall(BowlingBallSO ballSO)
    {
        if (CurrentBallInstance != null)
            Destroy(CurrentBallInstance);
        
        CurrentBallInstance = Instantiate(ballSO.ball, transform.position, transform.rotation);
        CurrentBallSO = ballSO;
    }
    
    public void RespwanBall() => SpawnBall(CurrentBallSO);
}
