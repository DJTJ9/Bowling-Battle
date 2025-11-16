using DependencyInjection;
using UnityEngine;

public class UIManager : MonoBehaviour, IDependencyProvider
{
    [SerializeField] private Canvas playerUI;
    
    [Provide] UIManager ProvideUIManager() => this;
    
    public void ShowPlayerUI() => playerUI.enabled = true;
    
    public void HidePlayerUI() => playerUI.enabled = false;
}
