using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonBall class handles the properties and functionality of the CannonBall
[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour 
{
	[Header("CannonBall Properties")]
	public int damage = 1;

	[SerializeField] private float magnitude; //the force applied to the rigidbody when spawned
	[SerializeField] private float deSpawnTime; //the time it takes for the cannon to despawn once it spawned

	//private variables
	private float despawnTimer = 0.0f;

	//Components Required
	private Rigidbody rbProjectile;

	private void Start()
	{
		//Gets the gameObject's rigidbody and apply a forward force
		rbProjectile = gameObject.GetComponent<Rigidbody>();
		rbProjectile.AddForce(transform.forward * magnitude);
	}

	private void Update()
	{
		DespawnTimerUpdate();
	}

	private void OnCollisionEnter(Collision coll)
	{
		OnTargetCollision(coll);


	}

	//When the cannonball collides and tries to find if the other Collider has a target script.
	//if it does the target will take damage.
	private void OnTargetCollision(Collision collTarget)
	{
		BaseTarget target = collTarget.gameObject.GetComponent<BaseTarget>();
		if(target != null)
		{
			target.TakeDamage(damage);
			Destroy(gameObject);
		}
	}

	//Destroys gameobject after a certain amount of timer
	private void DespawnTimerUpdate()
	{
		despawnTimer += Time.deltaTime;
		if(despawnTimer >= deSpawnTime)
		{
			Destroy(gameObject);
		}
	}
}
