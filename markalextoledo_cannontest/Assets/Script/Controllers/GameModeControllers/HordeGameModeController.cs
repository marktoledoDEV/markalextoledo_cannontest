using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeGameModeController : BaseGameModeController<HordeGameModeModel>
{
    [Header("Reference Needed")]
    public List<RandomSpawner> randomSpawnerList = new List<RandomSpawner>();

    protected override void SetupController()
    {
        base.SetupController();
        //Grab the total amount of enemies all the spawners in the level will spawn out
        //also have a method subscribe to a onTargetDestroyed delegate
        foreach(RandomSpawner spawner in randomSpawnerList)
        {
            GameModel.TargetsKillGoal += spawner.spawnAmount;
            spawner.onTargetDestroyedSubscriber += UpdateKillCount;
            spawner.isSpawnings = true;
        }
    }

    protected override void UpdateController()
    {
        if(GameModel.isDone) { return;}
        if(GameModel.TargetKilled >= GameModel.TargetsKillGoal)
        {
            Debug.Log("We Win");
            GameModel.isDone = true;
        }
    }

    public void UpdateKillCount()
    {
        GameModel.TargetKilled++;
    }
}
