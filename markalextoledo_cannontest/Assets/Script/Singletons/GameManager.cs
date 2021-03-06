﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to access important references in the game scene
public class GameManager : Singleton<GameManager> 
{
	public CannonController player; //a reference to the player for any class to access
	public MenuStateMachine menuStateMachine; //A reference to the UI so other classes can manipulate it easily;

	//Store different gamecontrollers here
	public Dictionary<GameModesType,IBaseGameModeController> GameControllerDictionary = new Dictionary<GameModesType, IBaseGameModeController>();
	private IBaseGameModeController currentActiveGameController = null;

	private void OnDestroy()
	{
		//ResetTime
		Time.timeScale = 1.0f;
	}

	protected override void SingletonAwake()
	{
		Debug.Log(gameObject.name + " has been Initialized");
	}

	//a getter for the currentActiveGameController
	public IBaseGameModeController GetCurretGameModeController()
	{
		return currentActiveGameController;
	}

	//Activates and sets up the desired gamemodecontroller
	//if applicable desetups the gamemodecontroller that is already in use
	public void ChangeGameModes(GameModesType mode)
	{
		if(currentActiveGameController != null)
		{
			currentActiveGameController.DesetupController();
		}

		bool changeSuccessful = GameControllerDictionary.TryGetValue(mode, out currentActiveGameController);
		if(changeSuccessful)
		{
			currentActiveGameController.SetupController();
		}
		else
		{
			Debug.LogError("CANNOT FIND GAMECONTROLLER: " + mode.ToString());
		}
	}
}
