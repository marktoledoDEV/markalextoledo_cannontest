﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Defines all the common properties and behaviours all Tarrgets will have
//Targets are enemies that will react to Cannonball;
[RequireComponent(typeof(Rigidbody))]
public class BaseTarget : MonoBehaviour 
{
	[Header("Target Properties")]
	[SerializeField] private int health = 5;

	//Components from gameObject required
	protected Rigidbody targetRigidbody;
	public Rigidbody TargetRigidBody { get { return targetRigidbody; } }

	private void Start()
	{
		InitializeTarget();
	}

	//Setup Target dependacies
	protected virtual void InitializeTarget()
	{
		targetRigidbody = gameObject.GetComponent<Rigidbody>();
	}

	public virtual void TakeDamage(int dmg)
	{
		health -= dmg;
		if(health <= 0)
		{
			TargetDies();
		}
	}

	public virtual void TargetDies()
	{
		Destroy(gameObject);
	}
}
