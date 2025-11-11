using DependencyInjection;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameInitiator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Light mainDirectionalLight;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private Injector injector;
    [SerializeField] private GameObject bowlingBall;
    [SerializeField] private Canvas PlayerUI;
    
    private BallMovement ballMovement;
    
    private void Awake()
    {
        
    }
    //TODO: * Make start method async to control initialisation steps order
    private void Start()
    {
        SceneManager.LoadScene("BowlingBattleLevel", LoadSceneMode.Additive);
        BindObjects();
        ballMovement = bowlingBall.GetComponent<BallMovement>();
        InjectDependencies();
        PrepareGame();
    }

    private void BindObjects()
    {
        bowlingBall = Instantiate(bowlingBall);
        mainCamera = Instantiate(mainCamera);
        mainDirectionalLight = Instantiate(mainDirectionalLight);
        eventSystem = Instantiate(eventSystem);
        globalVolume = Instantiate(globalVolume);
        PlayerUI = Instantiate(PlayerUI);
    }

    private void InjectDependencies()
    {
        injector = Instantiate(injector);
    }
    
    private void CreateObjects() { }

    private void PrepareGame()
    {
        ballMovement.GameStartConfiguration();
    }
}
