using System;
using DependencyInjection;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameScoreSO scoreSO;
    
    [Inject] private BallSpawner ballSpawner;

    private void OnTriggerEnter(Collider other) {
        if (scoreSO == null) return;
        
        scoreSO.Value += ballSpawner.BallSO.pointMultiplier;
    }

    private void OnTriggerExit(Collider other) {
        if (scoreSO == null) return;
        
        scoreSO.Value -= ballSpawner.BallSO.pointMultiplier;
    }
}
