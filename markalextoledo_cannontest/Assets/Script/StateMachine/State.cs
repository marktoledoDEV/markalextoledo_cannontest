

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description: An class that establishes the functions that a state could do in an Animator
public abstract class State : StateMachineBehaviour 
{
	public virtual string stateName { get; set; }

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
	}
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
	}
}
