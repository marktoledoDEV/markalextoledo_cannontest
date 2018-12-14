using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CannonController is responsible for the funcionality of the cannon and and attaching those funcionality to keyboard bindings
public class CannonController : MonoBehaviour 
{
	[Header("Cannon Properties")]
	[SerializeField] private float horizontalRotationSpeed; //the speed of Cannon moving left and right
	[SerializeField] private float verticalRotationSpeed;  //the speed of Cannon moving up and down
	[SerializeField] private float fireRate; //how many cannons spawned per second

	public enum playerInputOption { Horizontal, Vertical, Space }
	[Header("Player Controls")]
	[SerializeField] private playerInputOption horizontalAxisInput;
	[SerializeField] private playerInputOption verticalAxisInput;
	[SerializeField] private playerInputOption CannonFire;
}
