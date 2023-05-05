using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{

	protected T owner;
	protected FSM<T> fsm;

	public State(T owner, FSM<T> stateMachine)
	{
		this.owner = owner;
		fsm = stateMachine;
	}

	public abstract void Init();
	public abstract void Execute();
	public abstract void LastExecute();
	public abstract void End();

}
