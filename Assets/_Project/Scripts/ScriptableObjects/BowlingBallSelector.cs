using UnityEngine;
using DependencyInjection;

public class BowlingBallSelector : MonoBehaviour
{
    private GameObject ballPrefab;
    private BowlingBallSO ballSO;
    
    private GameObject ballInstance;
    
    [SerializeField] private BallMovement ballMovement;

    public void SetBallPrefab(BowlingBallSO ballSO)
    {
        ballPrefab = ballSO.ball;
        InstantiateBall();
    }

    private void InstantiateBall()
    {
        ballInstance = Instantiate(ballPrefab, ballMovement.transform.position, Quaternion.identity);
        ballInstance.transform.SetParent(ballMovement.transform);
        ballMovement.GameStartConfiguration();
    }
}