using System;
using UnityEngine;
using ImprovedTimers;
using Sirenix.OdinInspector;
using UnityEngine.Events;

public class BowlingBattleGameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onPreparationPhaseStart;
    [SerializeField] private UnityEvent onReleaseBall;
    [SerializeField] private UnityEvent onRoundEnd;
    [SerializeField] private UnityEvent onGameEnd;

    [SerializeField] private float preparationPhaseDuration = 10f;
    [SerializeField] private float roundDuration = 15f;
    [SerializeField] private int maxRounds = 3;

    private int roundIndex = 1;

    private CountdownTimer preparationPhaseTimer;
    private CountdownTimer roundTimer;

    [FoldoutGroup("Round Settings", expanded: true)]

private void Start()
    {
        ResetRoundIndex();
        
        preparationPhaseTimer = new CountdownTimer(preparationPhaseDuration);
        preparationPhaseTimer.OnTimerStop += ReleaseBall;
        
        roundTimer = new CountdownTimer(roundDuration);
        roundTimer.OnTimerStop += EndRound;
        
        onPreparationPhaseStart.Invoke();
    }

    private void OnDisable()
    {
        preparationPhaseTimer.OnTimerStop -= ReleaseBall;
        roundTimer.OnTimerStop -= EndRound;
    }

    public void StartPreparationPhase()
    {
        preparationPhaseTimer.Reset();
        preparationPhaseTimer.Start();
    }

    private void EndRound()
    {
        HandleRoundEnd();
        
        ++roundIndex;
    } 

    private void ReleaseBall()
    {
        onReleaseBall.Invoke();
        roundTimer.Reset();
        roundTimer.Start();
    }

    private void HandleRoundEnd()
    {
        if (roundIndex == maxRounds)
        {
            onGameEnd.Invoke();
            return;
        }
        
        onRoundEnd.Invoke();
        StartPreparationPhase();
    }
    
    private void ResetRoundIndex() => roundIndex = 1;
}
