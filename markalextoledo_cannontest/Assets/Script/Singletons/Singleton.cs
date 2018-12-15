using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

	public static T instance;

	private void Awake()
	{
		if(instance != null)
		{
			Destroy(this);
		}
		else
		{
			instance = (T)this;
			SingletonAwake();

		}
	}

	protected abstract void SingletonAwake();
}
