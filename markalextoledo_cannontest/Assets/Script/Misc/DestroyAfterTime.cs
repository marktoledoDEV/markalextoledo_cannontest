using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a small script that will destroy the gameobject it is attached
public class DestroyAfterTime : MonoBehaviour
{
    public float timeDelay = 1.0f;

    private void Start()
    {
        Destroy(gameObject,timeDelay);
    }
}
