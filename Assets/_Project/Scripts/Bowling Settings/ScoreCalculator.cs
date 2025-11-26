using System;
using DependencyInjection;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameScoreSO scoreSO;
    
    [Inject] private BallSpawner ballSpawner;

    public void ScoreChecker() 
    {
        if (-10f < transform.rotation.x || transform.position.x > 10f || -10f < transform.rotation.z || transform.position.z > 10f)
        {
            scoreSO.Value += ballSpawner.CurrentBallSO.pointMultiplier;
        }
    }
}
