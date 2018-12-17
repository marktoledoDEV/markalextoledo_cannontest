using System.Collections;
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
		if(targetSpawnedSubscriber != null)
		{
			targetSpawnedSubscriber();
		}
	}

	private void OnDestroy()
	{
		if(targetDestroyedSubscriber != null)
		{
			targetDestroyedSubscriber();
		}
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

	//Other classes can subscribe to when the target is spawned
	public delegate void onTargetSpawned();
	private onTargetSpawned targetSpawnedSubscriber;
	public onTargetSpawned TargetSpawnedSubscriber 
	{
		get
		{ 
			return targetSpawnedSubscriber; 
		}
		set
		{
			targetSpawnedSubscriber += value;
		}
	}

	//Other classes can subscribe actions to it, and is called when the target is destroyed
	public delegate void onTargetDestroyed();
	private onTargetDestroyed targetDestroyedSubscriber;
	public onTargetDestroyed TargetDestroyedSubscriber 
	{
		get
		{ 
			return targetDestroyedSubscriber; 
		}
		set
		{
			targetDestroyedSubscriber += value;
		}
	}

	public virtual void TargetDies()
	{
		Destroy(gameObject);
	}
}
