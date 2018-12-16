using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to define all the different types of gamemodes available
public enum GameModesType { Horde, TargetPractice }

public abstract class BaseGameModeController : MonoBehaviour
{
    public GameModesType GameMode;

    private void Awake()
    {
        InitializeController();
    }

    private void Update()
    {
        UpdateController();
    }

    public abstract void SetupController();
    public abstract void UpdateController();
    public abstract void DesetupController();

    private void InitializeController()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.GameControllerDictionary.Add(GameMode,this);
        }

        gameObject.SetActive(false);
    }
}
