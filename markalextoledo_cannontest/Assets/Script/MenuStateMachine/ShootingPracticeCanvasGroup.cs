using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingPracticeCanvasGroup : MenuCanvasGroup
{
    [Header("References Needed")]
    public Text txtTimer; //will display the amount of time left
    public Text txtTargetsKiled; //will display the Target Killed
    public ShootingPracticeGameModel GameModel;

    public override void OnStateEnter()
    {
        GameManager.instance.ChangeGameModes(GameModesType.ShootingPractice);
    }

    protected override void OnStateUpdate()
    {   
        txtTimer.text = "Time: " + (int) GameModel.gameTimer;
        txtTargetsKiled.text = "Targets Killed: " + GameModel.targetsKilled;
    }
}
