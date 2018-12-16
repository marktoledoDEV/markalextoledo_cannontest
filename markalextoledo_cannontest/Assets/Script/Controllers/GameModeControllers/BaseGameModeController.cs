using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to define all the different types of gamemodes available
public enum GameModesType { Horde, TargetPractice }

//Defines all the properties and behaviours any GameModeController will have
public abstract class BaseGameModeController<tGameModel> : MonoBehaviour where tGameModel : BaseGameModeModel
{
    public GameModesType GameMode; //The type of gameMode this gamemodecontroller is. Use it like an ID
    public tGameModel GameModel; // The GameModel this gamemodecontroller needs to run the game loop properly

    private void Awake()
    {
        InitializeController();
    }

    private void Update()
    {
        UpdateController();
    }

    public abstract void SetupController(); //called when gamemodeController is activated
    public abstract void UpdateController(); //runs the game logic of the gameModeController
    public abstract void DesetupController(); //called when gamemodeController is no longer active

    //Sets up any dependacies and executes any actions before the gameModeController is in use
    private void InitializeController()
    {
        //provide a reference of itself to the GameManager
        if(GameManager.instance != null)
        {
            GameManager.instance.GameControllerDictionary.Add(GameMode,gameObject.GetComponent<BaseGameModeController<BaseGameModeModel>>());
        }

        gameObject.SetActive(false);
    }
}
