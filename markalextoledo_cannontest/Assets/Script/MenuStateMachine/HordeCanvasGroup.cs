using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Sets up and displays all UI needed for HordeMode
public class HordeCanvasGroup : MenuCanvasGroup
{
    [Header("References")]
    public Text txtPlayerHealth; //will display the player's current health
    public Text txtEnemiesLeft; //displays how many targets left to be Killed
    public HordeGameModeModel GameModel;

    //Triggers the Horde Game Mode
    public override void OnStateEnter()
    {
        GameManager.instance.ChangeGameModes(GameModesType.Horde);
    }

    protected override void OnStateUpdate()
    {
        txtPlayerHealth.text = "Health: " + GameManager.instance.player.PlayerHealth;
        
        int enemiesLeft = GameModel.TargetsKillGoal - GameModel.TargetKilled;
        txtEnemiesLeft.text = "Targets Left: " + enemiesLeft;
    }
}
