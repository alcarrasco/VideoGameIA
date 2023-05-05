using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : State<NPC>
{
	public DieState(NPC owner, FSM<NPC> stateMachine) : base(owner, stateMachine)
	{

	}

	public override void End()
	{

	}

	public override void Execute()
	{

	}

	public override void Init()
	{
		Debug.Log("Adios mundo cruel!!!");
	}

	public override void LastExecute()
	{

	}
}
