using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//The HordeTarget is an moving target that will move towards the player and blow up and deal damage
[RequireComponent(typeof(NavMeshAgent))]
public class HordeTarget : BaseTarget 
{
	[Header("Horde Specific Properties")]
	public int hordeDamage = 1; //how much damage the horde will deal when it explodes.
	public float blastRadius = 10.0f; //how big the the explosion will be
	public float distanceFromCannon = 8.0f; //how far the target needs to be in order explode
	public float blowUpTime = 5.0f; //the delay before the it will blow up

	[SerializeField] private float hordeMoveSpeed = 5.0f;

	[Header("References and Components Required")]
	private NavMeshAgent nmAgent;
	public NavMeshAgent hordeNavMeshAgent { get{ return nmAgent; } }
	public GameObject ExplosionParticlePrefab; //Will spawn when target dies

	//References Needed
	private Transform playerCannon; // will move towards the cannon
	public Transform PlayerCannon { get{ return playerCannon; } }

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		playerCannon = GameManager.instance.player.transform;

		nmAgent = GetComponent<NavMeshAgent>();
		nmAgent.speed = hordeMoveSpeed;
		nmAgent.stoppingDistance = distanceFromCannon;
		
	}
	
}
