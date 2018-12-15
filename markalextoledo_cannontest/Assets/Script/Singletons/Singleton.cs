using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Define a singleton behaviour so any class that inherits from this class will act like a Singleton
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
	//All Singletons will setup all dependecies here
	protected abstract void SingletonAwake();
}
