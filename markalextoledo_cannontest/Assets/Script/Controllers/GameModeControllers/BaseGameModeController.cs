using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to define all the different types of gamemodes available
public enum GameModesType { Horde, ShootingPractice }

public interface IBaseGameModeController 
{
    void SetupController();//called when gamemodeController is activated
    void DesetupController();
}

//Defines all the properties and behaviours any GameModeController will have
public abstract class BaseGameModeController<tGameModel> : MonoBehaviour , IBaseGameModeController where tGameModel : BaseGameModeModel
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

    void IBaseGameModeController.SetupController()
    {
        this.SetupController();
        gameObject.SetActive(true);
    }
    protected abstract void SetupController();

    public abstract void UpdateController(); //runs the game logic of the gameModeController

    void IBaseGameModeController.DesetupController()
    {
        this.DesetupController();
        gameObject.SetActive(false);
    }
    protected virtual void DesetupController(){ } 
    //Sets up any dependacies and executes any actions before the gameModeController is in use
    private void InitializeController()
    {
        //provide a reference of itself to the GameManager
        if(GameManager.instance != null)
        {
            BaseGameModeController<tGameModel> controller = gameObject.GetComponent<BaseGameModeController<tGameModel>>();
            GameManager.instance.GameControllerDictionary.Add(GameMode,controller);
        }

        gameObject.SetActive(false);
    }
}
