using DependencyInjection;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUIEvents : MonoBehaviour
{
    [SerializeField] private BowlingBallCollectionSO ballCollectionSO;
    
    private UIDocument document;
    
    private VisualElement middlePlayerUI;
    
    private Button basketBallButton;
    private Button baseBallButton;
    private Button footBallButton;
    
    [Inject] private BallSpawner ballSpawner;

    private void Awake()
    {
            document = GetComponent<UIDocument>();
            
            middlePlayerUI = document.rootVisualElement.Q("player-ui-middle__container");
        
            baseBallButton = document.rootVisualElement.Q("ball-selector-baseball__button") as Button;
            baseBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(ballCollectionSO.BowlingBalls[BallType.Baseball]));
            basketBallButton = document.rootVisualElement.Q("ball-selector-basketball__button") as Button;
            basketBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(ballCollectionSO.BowlingBalls[BallType.Basketball]));
            footBallButton = document.rootVisualElement.Q("ball-selector-football__button") as Button;
            footBallButton?.RegisterCallback<ClickEvent>(evt => SpawnBall(ballCollectionSO.BowlingBalls[BallType.Football]));
    }

    private void SpawnBall(BowlingBallSO ballSO)
    {
        ballSpawner.SpawnBall(ballSO);
    }

    public void ShowMiddlePlayerUI()
    {
        middlePlayerUI.style.display = DisplayStyle.Flex;
    }
    
    public void HideMiddlePlayerUI()
    {
        middlePlayerUI.style.display = DisplayStyle.None;
    }
}
