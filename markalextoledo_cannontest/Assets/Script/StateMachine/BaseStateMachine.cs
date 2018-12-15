
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Description: Keeps states of its type consistent and in line
[RequireComponent(typeof(Animator))]
public abstract class BaseStateMachine : MonoBehaviour
{
	//Components Required
	private Animator smAnimator;

	protected virtual void Awake()
	{
		smAnimator = GetComponent<Animator>();
		InitializeStates();
	}

	//Will bind any states from the animator together to make it easily accessible to the state machine
	protected abstract void InitializeStates();
	//Will be called in a statemachine controller to refresh the statemachine
	public abstract void RefreshStateMachine(int trigger);
}
