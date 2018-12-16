using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to access important references in the game scene
public class GameManager : Singleton<GameManager> 
{
	public CannonController player; //a reference to the player for any class to access

	//Store different gamecontrollers here
	public Dictionary<GameModesType,BaseGameModeController<BaseGameModeModel>> GameControllerDictionary = new Dictionary<GameModesType, BaseGameModeController<BaseGameModeModel>>();
	private BaseGameModeController<BaseGameModeModel> currentActiveGameController = null;

	protected override void SingletonAwake()
	{
		Debug.Log(gameObject.name + " has been Initialized");
	}

	//a getter for the currentActiveGameController
	public BaseGameModeController<BaseGameModeModel> GetCurretGameModeController()
	{
		return currentActiveGameController;
	}

	//Activates and sets up the desired gamemodecontroller
	//if applicable desetups the gamemodecontroller that is already in use
	public void ChangeGameModes(GameModesType mode)
	{
		if(currentActiveGameController != null)
		{
			currentActiveGameController.gameObject.SetActive(false);
			currentActiveGameController.DesetupController();
		}

		bool changeSuccessful = GameControllerDictionary.TryGetValue(mode, out currentActiveGameController);
		if(changeSuccessful)
		{
			currentActiveGameController.gameObject.SetActive(true);
			currentActiveGameController.SetupController();
		}
		else
		{
			Debug.LogError("CANNOT FIND GAMECONTROLLER: " + mode.ToString());
		}
	}
}
