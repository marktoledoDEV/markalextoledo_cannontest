using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//The HordeTarget is an moving target that will move towards the player and blow up and deal damage
[RequireComponent(typeof(NavMeshAgent))]
public class HordeTarget : BaseTarget 
{
	[Header("Horde Specific Target")]
	public int hordeDamage = 1;

	[SerializeField] private float hordeMoveSpeed = 5.0f;

	//Components Required
	private NavMeshAgent nmAgent;
	public NavMeshAgent hordenavMeshAgent { get{ return nmAgent; } }

	//References Needed
	private Transform playerCannon; // will move towards the cannon
	public Transform PlayerCannon { get{ return playerCannon; } }

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		playerCannon = GameManager.instance.player.transform;

		nmAgent = GetComponent<NavMeshAgent>();
		
	}

	
}
