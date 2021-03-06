﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//GameModeModel will hold information needed for the GameModeControllers tofunction
//BaseGameModeModel will define some behaviours for the GameModeModel
[System.Serializable]
public abstract class BaseGameModeModel : ScriptableObject
{   

    public bool isDone = false;
    private void Awake()
    {
        ResetGameModel();
    }

    //revert any changes the gameModel might have taken
    public virtual void ResetGameModel()
    {
        isDone = false;
    }

    protected static BaseGameModeModel CreateGameModeModel<tGameModel>() where tGameModel : BaseGameModeModel
    {
        tGameModel gameModeModel = ScriptableObject.CreateInstance<tGameModel>();

        AssetDatabase.CreateAsset(gameModeModel,"Assets/Assets/ScriptableObjects/GameModeModels/GameModeModel.asset");
        AssetDatabase.SaveAssets();
        return gameModeModel;
    }
}
