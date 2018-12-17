using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The game logic for the Shooting Practice Game Mode goes in here
public class ShootingPracticeGameModeController : BaseGameModeController<ShootingPracticeGameModel>
{
    //References
    public ShootingRangeSpawner targetSpawner;

    //Private Properties
    List<BaseTarget> targetList = new List<BaseTarget>();

    protected override void SetupController()
    {
        base.SetupController();
        targetSpawner.AdjustShootinRangeSpawnerValues(GameModel.gridHeight,GameModel.gridWidth);
        targetSpawner.SetSpawnAmount(GameModel.numberOfTargets);
        targetList = targetSpawner.GenerateShootingRange();
        foreach(BaseTarget target in targetList)
        {
            target.TargetDestroyedSubscriber += TargetKilled;
        }

        GameModel.gameTimer = GameModel.TimeGiven;
    }
    protected override void UpdateController()
    {
        if(!GameModel.isDone)
        {
            if(GameModel.targetsKilled >= GameModel.numberOfTargets)
            {
                Debug.Log("YOU WIN");
                GameModel.isDone = true;
                return;
            }
            
            UpdateGameTimer();
        }
    }

    protected override void DesetupController()
    {
        base.DesetupController();
    }

    //Calculates how much time the player has to solve to complete the task
    private void UpdateGameTimer()
    {
        Debug.Log("[Shooting Range] Time Left: " + GameModel.gameTimer);
        GameModel.gameTimer -= Time.deltaTime;
        if(GameModel.gameTimer <= 0.0f)
        {
            GameModel.gameTimer = 0.0f;
            GameModel.isDone = true;
            Debug.Log("TIME RAN OUT");
        }
    }

    private void TargetKilled()
    {
        Debug.Log("TARGET KILLED");
        GameModel.targetsKilled++;
    }
}
