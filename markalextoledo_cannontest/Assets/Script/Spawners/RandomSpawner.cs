using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Will Spawn targets at a random time 
public class RandomSpawner : BaseSpawner
{
    [Header("Random Spawner Specific Properties")]
    [SerializeField] private float minSpawnTime = 1.0f; //The minimum time between each time the spawner spawns something
    [SerializeField] private float maxSpawnTime = 10.0f; // the maximum time between each time the spawner spawns something

    [HideInInspector] public bool isSpawnings = false;

    private float spawnTimer = 0.0f; //internal timer to keep track when to spawn things
    private float spawnTime = 0.0f; //internal time the timer needs to reach to spawn something
    private float spawnAmountLeft = 0.0f;

    private void Update()
    {
        if(isSpawnings)
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnTime)
            {
                //Reset timer and Spawns
                SetNewTime();
                spawnTimer = 0.0f;
                spawnAmountLeft--;

                //Spawn new target and will add any delegates the target might neeed to function in a certain game mode
                GameObject targetGO = Spawn(transform.position,transform.rotation);
                BaseTarget target = targetGO.GetComponent<BaseTarget>();
                if(target != null && onTargetDestroyedSubscriber != null)
                {
                    target.TargetDestroyedSubscriber += onTargetDestroyedSubscriber;
                }
            }

            //Called once we spawn the desired amount
            if(spawnAmountLeft <= 0)
            {
                isSpawnings = false;
            }
        }
    }

    protected override void InitializeSpawner()
    {    
        base.InitializeSpawner();
        SetNewTime();
        spawnAmountLeft = spawnAmount;
    }

    //Generate a new time for the spawnTime
    private void SetNewTime()
    {
        spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
        Debug.LogWarning("New SpawnTime: " + spawnTime);
    }

    public BaseTarget.onTargetDestroyed onTargetDestroyedSubscriber;
}
