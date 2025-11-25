using UnityEngine;
using ImprovedTimers;
using UnityEngine.Events;

public class BowlingBattleGameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onPreparationPhaseStart;
    [SerializeField] private UnityEvent onReleaseBall;
    [SerializeField] private UnityEvent onRoundEnd;
    
    [SerializeField] private float preparationPhaseDuration = 10f;
    [SerializeField] private float roundDuration = 15f;
    
    private CountdownTimer preparationPhaseTimer;
    private CountdownTimer roundTimer;
    
    private void Start()
    {
        onPreparationPhaseStart.Invoke();
        
        preparationPhaseTimer = new CountdownTimer(preparationPhaseDuration);
        preparationPhaseTimer.OnTimerStop += ReleaseBall;
        
        roundTimer = new CountdownTimer(roundDuration);
        roundTimer.OnTimerStop += PrepareNextRound;
        roundTimer.OnTimerStart += StartPreparationPhase;
    }

    public void StartPreparationPhase()
    {
        preparationPhaseTimer.Reset();
        preparationPhaseTimer.Start();
    }

    private void PrepareNextRound() => onRoundEnd.Invoke();

    private void ReleaseBall()
    {
        onReleaseBall.Invoke();
        roundTimer.Reset();
        roundTimer.Start();
    } 
    
}
