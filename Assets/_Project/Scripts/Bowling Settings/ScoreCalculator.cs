using System;
using DependencyInjection;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameScoreSO scoreSO;
    // [SerializeField] private LayerMask groundLayer;
    
    [Inject] private BallSpawner ballSpawner;

    private void OnTriggerEnter(Collider other) 
    {
        if (scoreSO == null) return;
        
        scoreSO.Value += ballSpawner.CurrentBallSO.pointMultiplier;
    }

    // private void OnTriggerExit(Collider other) 
    // {
    //     if (scoreSO == null) return;
    //     
    //     scoreSO.Value -= ballSpawner.CurrentBallSO.pointMultiplier;
    // }
}
