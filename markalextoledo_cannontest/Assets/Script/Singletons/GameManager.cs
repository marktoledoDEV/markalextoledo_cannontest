using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//An easy way to access important references in the game scene
//for a test commit
public class GameManager : Singleton<GameManager> 
{
	public CannonController player;

	protected override void SingletonAwake()
	{
		Debug.Log(gameObject.name + " has been Initialized");
	}
}
