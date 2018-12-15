using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All the States That Are Made for the HordeTarget

//The HordeTarget state names
public enum HordeStates { Moving, BlowUp }

//Setups dependacies for all HordeTarget States
public abstract class BaseHordeState : State
{
	//References
	protected HordeTarget hordeModel;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		hordeModel = animator.gameObject.GetComponent<HordeTarget>();
		if(hordeModel == null)
		{
			Debug.LogError("HordeModel is null");
			return;
		}
	}
	
}