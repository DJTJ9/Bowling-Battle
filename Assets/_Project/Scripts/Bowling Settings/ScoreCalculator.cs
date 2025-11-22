using System;
using DependencyInjection;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameScoreSO scoreSO;
    
    private bool hasFallen;
    
    [Inject] private BallSpawner ballSpawner;

    private void OnTriggerEnter(Collider other) {
        if (scoreSO == null) return;
        
        scoreSO.Value += ballSpawner.BallSO.pointMultiplier;
        hasFallen = true;
    }

    private void OnTriggerExit(Collider other) {
        if (scoreSO == null) return;
        
        hasFallen = false;
        scoreSO.Value -= ballSpawner.BallSO.pointMultiplier;
    }
}
