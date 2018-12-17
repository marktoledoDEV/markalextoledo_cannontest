using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HordeGameModeModel : BaseGameModeModel
{
    //Revertable Values
    [HideInInspector] public int TargetsKillGoal = 0; //The Amount of targets killed to win the gamemode
    [HideInInspector] public int TargetKilled = 0; //the amount of targets the player has killed so far

    public override void ResetGameModel()
    {
        base.ResetGameModel();
        TargetKilled = 0;
        TargetsKillGoal = 0;
    }

    [MenuItem("Assets/Create/Create Horde Game Mode Model")]
    public static void CreateHordeGameModeModel()
    {
        BaseGameModeModel.CreateGameModeModel<HordeGameModeModel>();
    }
}
