using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Game Score", menuName = "Scriptable Objects/Game Score", order = 1)]
public class GameScoreSO : ScriptableObject
{
    public float Value = 0;

    private void OnEnable()
    {
        Value = 0;
    }
}
