using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The game logic for the Shooting Practice Game Mode goes in here
public class ShootingPracticeGameModeController : BaseGameModeController<ShootingPracticeGameModel>
{
    //References
    public ShootingRangeSpawner targetSpawner;

    protected override void SetupController()
    {
        targetSpawner.AdjustShootinRangeSpawnerValues(GameModel.gridHeight,GameModel.gridWidth);
        targetSpawner.SetSpawnAmount(GameModel.numberOfTargets);
        targetSpawner.GenerateShootingRange();
    }
    public override void UpdateController(){ }
    protected override void DesetupController(){ }
}
