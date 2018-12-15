using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains the properties and functionality for all spawners
public abstract class BaseSpawner : MonoBehaviour 
{
	[Header("Spawner Properties")]
	[SerializeField] private GameObject spawneePrefab;
	public int spawnAmount = 10; //howmuch spawneePrefab will be spawned;

	private void Awake()
	{
		InitializeSpawner();
	}

	//Setup dependacies for spawners
	protected virtual void InitializeSpawner() {	}

	//quick function to spawn the spawner's spawneePrefab
	public GameObject Spawn(Vector3 position, Quaternion rotation)
	{
		return Instantiate(spawneePrefab,position, rotation);
	}
		public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent)
	{
		return Instantiate(spawneePrefab,position, rotation,parent);
	}
}
