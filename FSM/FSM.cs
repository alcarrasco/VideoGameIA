using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{

	List<State<T>> states = new List<State<T>>();
	State<T> currentState;



	public void Update()
	{
		if (currentState != null) currentState.Execute();

	}

	public void LateUpdate()
	{
		if (currentState != null) currentState.LastExecute();
	}

	public void AddState(State<T> newState)
	{
		states.Add(newState);
		if (currentState == null)
		{
			currentState = newState;
			currentState.Init();
		}
	}

	public void SetState<K>() where K : State<T>
	{
		for (int i = 0; i < states.Count; i++)
		{
			if(states[i].GetType() == typeof(K))
			{
				currentState.End();
				currentState = states[i];
				currentState.Init();
				Debug.Log("State: " + currentState.GetType());
				break;
			}
		}
	}
}
