using System;
using DependencyInjection;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private float isFallenDotProductThreshold = 0.7f;
    [SerializeField] private GameScoreSO scoreSO;
    
    [Inject] private BallSpawner ballSpawner;

    public void ScoreChecker() 
    {
        float dotProduct = Vector3.Dot(transform.up, Vector3.up);
        bool isFallen = dotProduct < isFallenDotProductThreshold;
        
        if (isFallen)
        {
            scoreSO.Value += ballSpawner.CurrentBallSO.pointMultiplier;
        }
    }
}
