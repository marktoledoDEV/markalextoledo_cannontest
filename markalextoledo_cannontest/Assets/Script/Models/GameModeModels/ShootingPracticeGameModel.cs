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

    //Revertable Values
    private int targetsKilled = 0;

    public override void ResetGameModel()
    {
        targetsKilled = 0;
    }

    [MenuItem("Assets/Create/Create Shooting Pracitce Game Mode Model")]
    public static void CreateShootingPracticeGameModeModel()
    {
        BaseGameModeModel.CreateGameModeModel<ShootingPracticeGameModel>();
    }

    
}
