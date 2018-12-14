using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonBall class handles the properties and functionality of the CannonBall
[RequireComponent(typeof(Rigidbody))]
public class CannonBall : MonoBehaviour 
{
	[Header("CannonBall Properties")]
	[SerializeField] private float magnitude; //the force applied to the rigidbody when spawned
	[SerializeField] private float deSpawnTime; //the time it takes
	//Components Required
	private Rigidbody rbProjectile;

	private void Start()
	{
		rbProjectile = gameObject.GetComponent<Rigidbody>();
		rbProjectile.AddRelativeForce(transform.forward * magnitude,ForceMode.Acceleration);
	}
}
