using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonBall class handles the properties and functionality of the CannonBall
[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour 
{
	[Header("CannonBall Properties")]
	[SerializeField] private float magnitude; //the force applied to the rigidbody when spawned
	[SerializeField] private float deSpawnTime; //the time it takes for the cannon to despawn once it spawned

	//private variables
	private float despawnTimer = 0.0f;

	//Components Required
	private Rigidbody rbProjectile;

	private void Start()
	{
		rbProjectile = gameObject.GetComponent<Rigidbody>();
		rbProjectile.AddRelativeForce(transform.forward * magnitude);
	}

	private void Update()
	{
		DespawnTimerUpdate();
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
