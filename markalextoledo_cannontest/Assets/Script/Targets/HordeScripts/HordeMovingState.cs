using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will move the HordeTarget towards the cannon.
//Once close enough it will transistion state
public class HordeMovingState : BaseHordeState 
{
	public override string stateName { get { return HordeStates.Moving.ToString();} }

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator,stateInfo,layerIndex);
		
		if(hordeModel.hordeNavMeshAgent.isActiveAndEnabled)
		{
			hordeModel.hordeNavMeshAgent.SetDestination(hordeModel.PlayerCannon.position);
		}
		float distance = Vector3.Distance(hordeModel.transform.position, hordeModel.PlayerCannon.position);
		if(distance <= hordeModel.distanceFromCannon)
		{
			animator.SetTrigger("BlowUp");
		}
	}
}
