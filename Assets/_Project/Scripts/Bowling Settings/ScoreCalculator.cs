using System;
using DependencyInjection;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameScoreSO scoreSO;
    
    [SerializeField] private BoxCollider groundCollider;

    private bool hasFallen;
    
    [Inject] private BallSpawner ballSpawner;

    private void Awake() {
    }

    private void OnTriggerEnter(Collider other) {
        // if (hasFallen || other != groundCollider) return;
        // if (scoreSO == null) return;
        scoreSO.Value += ballSpawner.BallSO.pointMultiplier;
        // scoreSO.Value += 1f;
        hasFallen = true;
    }

    private void OnTriggerExit(Collider other) {
        hasFallen = false;
        scoreSO.Value -= 1f;
    }
}
