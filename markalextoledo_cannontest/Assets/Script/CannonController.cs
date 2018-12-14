﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonController is responsible for the funcionality of the cannon and and attaching those funcionality to keyboard bindings
public class CannonController : MonoBehaviour 
{
	[Header("Cannon Properties")]
	[SerializeField] private float horizontalRotationSpeed = 1.0f; //the speed of Cannon moving left and right
	[SerializeField] private float verticalRotationSpeed = 1.0f;  //the speed of Cannon moving up and down
	[SerializeField] private float fireRate = 1.0f; //how many cannons spawned per second
	
	[Header("References and Prefabs")]
	[SerializeField] private GameObject cannonballPrefab;
	[SerializeField] private Transform cannonPivot;
	[SerializeField] private Transform spawnPoint;

	public enum playerInputOption { Horizontal, Vertical, Space }
	[Header("Player Controls")]
	[SerializeField] private playerInputOption horizontalAxisInput; //the input used to control horizontal movement
	[SerializeField] private playerInputOption verticalAxisInput; //the input used to control vertical movemnet
	[SerializeField] private KeyCode CannonFire; //the input to control firing the cannon

	private void Update()
	{
		CannonRotationUpdate();
		CannonFireUpdate();
	}

	//Calculates how much to rotate the cannon pivot and in which direction
	private void CannonRotationUpdate()
	{
		float horizontalValue = Input.GetAxis(horizontalAxisInput.ToString()) * horizontalRotationSpeed;
		float verticalValue = Input.GetAxis(verticalAxisInput.ToString()) * verticalRotationSpeed;
		cannonPivot.eulerAngles += new Vector3(verticalValue, horizontalValue, 0.0f);
	}

	private void CannonFireUpdate()
	{
		if(Input.GetKeyDown(CannonFire))
		{
			Instantiate(cannonballPrefab,spawnPoint.position, spawnPoint.rotation);
		}
	}
}
