using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeAttackState : BaseHordeState 
{
	public override string stateName { get{ return HordeStates.BlowUp.ToString(); } }

	//Private Properties
	private float delayTimer = 0.0f;

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateUpdate(animator,stateInfo,layerIndex);

		delayTimer += Time.deltaTime;
		if(delayTimer >= hordeModel.blowUpTime)
		{
			delayTimer = 0.0f;
			HordeTargetExplodes();
			Destroy(hordeModel.gameObject);
		}
	}

	private void HordeTargetExplodes()
	{
		Collider[] collidersInRange = Physics.OverlapSphere(hordeModel.transform.position,hordeModel.blastRadius);
		for(int i = 0; i < collidersInRange.Length; i++)
		{
			CannonController cannon = collidersInRange[i].gameObject.GetComponent<CannonController>();
			if(cannon != null)
			{
				cannon.TakeDamage(hordeModel.hordeDamage);
			}
		}
	}
}
