using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MenuCanvasGroup handles the specific functionalities of each individual menu
[RequireComponent(typeof(CanvasGroup))]
public class MenuCanvasGroup : MonoBehaviour 
{
	//Properties and Fields
	public MenuStateName stateName;

	//Components
	public CanvasGroup canvasGroup;

	//Unity Methods
	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		OnStateUpdate();
	}

	//Custom Methods
	public virtual void OnStateEnter() { }
	protected virtual void OnStateUpdate() { }
	public virtual void OnStateExit() { }
}

