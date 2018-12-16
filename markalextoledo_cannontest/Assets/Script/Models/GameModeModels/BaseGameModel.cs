using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameModeModel : ScriptableObject
{   
    private void Awake()
    {
        ResetGameModel();
    }

    //revert any changes the gameModel might have taken
    public abstract void ResetGameModel();
}
