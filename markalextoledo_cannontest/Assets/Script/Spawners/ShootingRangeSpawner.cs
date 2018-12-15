using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//will spawn the desired game objects randomly throughout a grid.
public class ShootingRangeSpawner : BaseSpawner 
{
	[Header("Shooting Range Spawner Properties")]
	[SerializeField] private int gridHeight = 10;
	[SerializeField] private int gridWidth = 10;
	[SerializeField] private float spawnSpacing = 10.0f; //the space between each spawneePrefab

	//private properties
	private bool[,] SpawnGrid; //Spawngrid will be useed

	//set up the dimensions of the spawn grid
	protected override void InitializeSpawner()
	{
		ResetSpawnGrid();
		GenerateShootingRange();
	}

	public void GenerateShootingRange()
	{
		for(int i = 0; i < spawnAmount; i++)
		{
			bool foundUnusedPosition = false;
			while(foundUnusedPosition == false)
			{
				int rndHeight = Random.Range(0,gridHeight);
				int rndWidth = Random.Range(0,gridWidth);

				if(!SpawnGrid[rndWidth,rndHeight])
				{
					float xPos = rndWidth + spawnSpacing;
					float yPos = rndHeight + spawnSpacing;
					Vector3 spawnPosition = new Vector3(xPos, yPos, 0.0f);
					GameObject spawnedTarget = Spawn(spawnPosition, transform.rotation,transform);
					spawnedTarget.transform.localPosition = spawnPosition;
					
					SpawnGrid[rndWidth,rndHeight] = true;
					foundUnusedPosition = SpawnGrid[rndWidth,rndHeight];
				}
			}
		}
	}

	private void ResetSpawnGrid()
	{
		SpawnGrid = new bool[gridWidth, gridHeight];
		for(int i = 0; i <gridWidth; i++)
		{
			for(int j = 0; j < gridHeight; j++)
			{
				SpawnGrid[i,j] = false;
			}
		}
	}
}
