using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to define all the different types of gamemodes available
public enum GameModesType { Horde, ShootingPractice }

public interface IBaseGameModeController 
{
    void SetupController();
    void DesetupController();
}

//Defines all the properties and behaviours any GameModeController will have
public abstract class BaseGameModeController<tGameModel> : MonoBehaviour, IBaseGameModeController where tGameModel : BaseGameModeModel
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

    private void OnDisable()
    {
        DesetupController();
    }

    //Define All the methods outline in the iBaseGameModeController interface;
    void IBaseGameModeController.SetupController()
    {
        this.SetupController();
    }

    void IBaseGameModeController.DesetupController()
    {
        this.SetupController();
    }

    //Sets up the gameplay loop 
    protected virtual void SetupController()
    {
        gameObject.SetActive(true);
    }  

    protected abstract void UpdateController(); //runs the game logic of the gameModeController

    protected virtual void DesetupController()
    {
        gameObject.SetActive(false);
        GameModel.ResetGameModel();
    } 
    //Sets up any dependacies and executes any actions before the gameModeController is in use
    private void InitializeController()
    {
        if(GameManager.instance != null)
        {
            GameManager.instance.GameControllerDictionary.Add(GameMode, this);
        }
        gameObject.SetActive(false);
    }
}
