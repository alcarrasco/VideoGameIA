using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : State<NPC>
{
	float elapsedTime;
	public FleeState(NPC owner, FSM<NPC> stateMachine) : base(owner, stateMachine)
	{

	}

	public override void End()
	{
		owner.Flee.Destination = null;
	}

	public override void Execute()
	{
		if (owner.NPCHasDied)
		{
			fsm.SetState<DieState>();
			return;
		}

		if(elapsedTime > 5f)
		{
			//fsm.SetState<LookForExitState>();
			fsm.SetState<EscapeState>();
			return;
		}

		if(owner.Target.value != null)
		{
			Vector3 dir = owner.Target.value.transform.position - owner.transform.position;
			owner.WP.Shoot(owner.transform.position + owner.transform.forward, dir);
		}

		elapsedTime += Time.deltaTime;
	}

	public override void Init()
	{
		owner.Flee.Destination = owner.Target.value.transform;
		elapsedTime = 0;
	}

	public override void LastExecute()
	{
	}
}
