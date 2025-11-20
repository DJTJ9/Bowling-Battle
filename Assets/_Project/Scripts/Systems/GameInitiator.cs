using DependencyInjection;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameInitiator : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Light mainDirectionalLight;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private Injector injector;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private BallMovement ballMovement;
    // [SerializeField] private Canvas PlayerUI;
    [SerializeField] private UIDocument playerUI;

    [SerializeField] private GameObject bowlingPins;

    //TODO: * Make start method async to control initialisation steps order
    private void Start()
    {
        SceneManager.LoadScene("BowlingBattleLevel", LoadSceneMode.Additive);
        BindObjects();
        InjectDependencies();
        PrepareGame();
    }

    private void BindObjects()
    {
        mainCamera = Instantiate(mainCamera);
        mainDirectionalLight = Instantiate(mainDirectionalLight);
        eventSystem = Instantiate(eventSystem);
        globalVolume = Instantiate(globalVolume);
        
        // ballMovement = Instantiate(ballMovement);
        ballSpawner = Instantiate(ballSpawner);
        // PlayerUI = Instantiate(PlayerUI);
        playerUI = Instantiate(playerUI);
        bowlingPins = Instantiate(bowlingPins);
    }

    private void InjectDependencies()
    {
        injector = Instantiate(injector);
    }

    private void CreateObjects()
    {
    }

    private void PrepareGame()
    {
        // ballMovement.GameStartConfiguration();
    }
}
