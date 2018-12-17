using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShootingPracticeGameModel : BaseGameModeModel
{
    [Header("Adjustable Values")]
    public int numberOfTargets = 010;
    public int gridWidth = 5;
    public int gridHeight = 5;
    public float TimeGiven = 60.0f;

    //Revertable Values
    public int targetsKilled = 0;
    public float gameTimer = 0.0f;

    public override void ResetGameModel()
    {
        base.ResetGameModel();
        targetsKilled = 0;
        gameTimer = 0.0f;
    }

    [MenuItem("Assets/Create/Create Shooting Pracitce Game Mode Model")]
    public static void CreateShootingPracticeGameModeModel()
    {
        BaseGameModeModel.CreateGameModeModel<ShootingPracticeGameModel>();
    }

    
}
