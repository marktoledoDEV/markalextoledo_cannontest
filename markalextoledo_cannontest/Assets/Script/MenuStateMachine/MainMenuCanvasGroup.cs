using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles all the behaviours for the MainMenu UI
public class MainMenuCanvasGroup : MenuCanvasGroup
{
    public override void OnStateEnter()
    {   
        //Pause the game
        Time.timeScale = 0.0f;

        //Find any targets still left over from the game and destroy them
        BaseTarget[] targetsInScene = GameObject.FindObjectsOfType<BaseTarget>();
        if(targetsInScene != null)
        {
            for(int i = 0; i < targetsInScene.Length; i++)
            {
                Destroy(targetsInScene[i].gameObject);
            }
        }
    }

    //Unpause the game once the main menu is finished
    public override void OnStateExit()
    {
        Time.timeScale = 1.0f;
    }
}
