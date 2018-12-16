using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to access important references in the game scene
public class GameManager : Singleton<GameManager> 
{
	public CannonController player; //a reference to the player for any class to access

	//Store different gamecontrollers here
	public Dictionary<GameModesType,BaseGameModeController> GameControllerDictionary = new Dictionary<GameModesType, BaseGameModeController>();
	private BaseGameModeController currentActiveGameController = null;

	protected override void SingletonAwake()
	{
		Debug.Log(gameObject.name + " has been Initialized");
	}

	//a getter for the currentActiveGameController
	public BaseGameModeController GetCurretGameModeController()
	{
		return currentActiveGameController;
	}

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
