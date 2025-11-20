using System.Collections.Generic;
using DependencyInjection;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUIEvents : MonoBehaviour
{
    private UIDocument document;
    
    [SerializeField] private BowlingBallSO basketballSO;
    [SerializeField] private BowlingBallSO baseballSO;
    [SerializeField] private BowlingBallSO footballSO;
    
    private Button basketBallButton;
    private Button baseBallButton;
    private Button footBallButton;
    
    [Inject] private BallSpawner ballSpawner;

    private void Awake()
    {
            document = GetComponent<UIDocument>();
        
            basketBallButton = document.rootVisualElement.Q("ball-selector-basketball__button") as Button;
            basketBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(basketballSO));
            baseBallButton = document.rootVisualElement.Q("ball-selector-baseball__button") as Button;
            baseBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(baseballSO));
            footBallButton = document.rootVisualElement.Q("ball-selector-football__button") as Button;
            footBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(footballSO));
    }

    private void SpawnBall(BowlingBallSO ballSO)
    {
        ballSpawner.SpawnBall(ballSO);
    }
}
