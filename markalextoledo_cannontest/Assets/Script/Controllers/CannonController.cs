using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonController is responsible for the funcionality of the cannon and and attaching those funcionality to keyboard bindings
public class CannonController : MonoBehaviour 
{
	[Header("Cannon Properties")]
	[SerializeField] private int health = 10; //the amount of damage the cannon can take before losing;

	[SerializeField] private float horizontalRotationSpeed = 1.0f; //the speed of Cannon moving left and right
	[SerializeField] private float verticalRotationSpeed = 1.0f;  //the speed of Cannon moving up and down
	
	[Header("References and Prefabs")]
	[SerializeField] private GameObject cannonballPrefab; //This is the gameobject that will shoot out of the cannon
	[SerializeField] private Transform cannonPivot; //This is what is going to be rotated the user controls
	[SerializeField] private Transform spawnPoint; //The position the cannonballPrefab will be spawned

	public enum playerInputOption { Horizontal, Vertical, Space }
	[Header("Player Controls")]
	[SerializeField] private playerInputOption horizontalAxisInput; //the input used to control horizontal movement
	[SerializeField] private playerInputOption verticalAxisInput; //the input used to control vertical movemnet
	[SerializeField] private KeyCode CannonFire; //the input to control firing the cannon

	private void Awake()
	{
		GameManager.instance.player = this; //give reference to itself so other classes can have an easy way of accessing the player
	}

	private void Update()
	{
		CannonRotationUpdate();
		CannonFireUpdate();
	}

	//Calculates how much to rotate the cannon pivot and in the proper direction
	private void CannonRotationUpdate()
	{
		//Calculate the how much to rotate the cannonPivot and apply it to the cannonPivot
		float horizontalValue = Input.GetAxis(horizontalAxisInput.ToString()) * horizontalRotationSpeed;
		float verticalValue = Input.GetAxis(verticalAxisInput.ToString()) * verticalRotationSpeed;
		cannonPivot.eulerAngles += new Vector3(verticalValue, horizontalValue, 0.0f);
	}

	//Handles the spawning of cannonballs
	private void CannonFireUpdate()
	{
		if(Input.GetKeyDown(CannonFire))  
		{
			Instantiate(cannonballPrefab,spawnPoint.position, cannonPivot.rotation);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
	}
}
