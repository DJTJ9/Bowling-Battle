using DependencyInjection;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectionButton : MonoBehaviour
{
    [SerializeField] private BowlingBallSO ballSO;
    [Inject] private BallSpawner ballSpawner;

    private Button button;
    
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }
    
    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        ballSpawner.SpawnBall(ballSO);
    }
}
