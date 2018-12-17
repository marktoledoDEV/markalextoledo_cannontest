


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the mechanic to transition between differnt menu states
public class MenuStateMachine : BaseStateMachine
{
	private Dictionary<MenuStateName,MenuCanvasGroup> menuDictionary = new Dictionary<MenuStateName, MenuCanvasGroup>();
	private MenuCanvasGroup currentMenuState = null;

	//Custom Methods
	protected override void InitializeStates()
	{	
		//Find all the MenuCanvasGroups and added them to a Dictionary for future use
		menuDictionary = new Dictionary<MenuStateName, MenuCanvasGroup>();
		MenuCanvasGroup[] menuCanvasCroups = GetComponentsInChildren<MenuCanvasGroup>();
		for(int i = 0; i < menuCanvasCroups.Length; i++)
		{
			menuDictionary.Add(menuCanvasCroups[i].stateName, menuCanvasCroups[i]);
			menuCanvasCroups[i].canvasGroup.alpha = 0.0f;
			menuCanvasCroups[i].gameObject.SetActive(false);
		}
	}

	//Called when there is a state change and exits the current state and enters the new state
	public override void RefreshStateMachine(int trigger) 
	{
		if(currentMenuState != null) 
		{
			currentMenuState.OnStateExit();
			currentMenuState.canvasGroup.alpha = 0.0f;
			currentMenuState.gameObject.SetActive(false);
		}

		bool sucessful= menuDictionary.TryGetValue((MenuStateName) trigger, out currentMenuState);
		if(sucessful)
		{
			currentMenuState.canvasGroup.alpha = 1.0f;
			currentMenuState.gameObject.SetActive(true);
			currentMenuState.OnStateEnter();
		}
		else
		{
			Debug.LogError("MenuState not found");
		}
	}
}
