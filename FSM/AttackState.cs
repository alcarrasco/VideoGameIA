using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<NPC>
{

	BlackboardEntry<GameObject> target;
	int LookOrIdle;

	public AttackState(NPC owner, FSM<NPC> stateMachine) : base(owner, stateMachine)
	{
		target = owner.Mem.GetOrCreate<GameObject>("ObjectSeen");
	}

	public override void End()
	{

	}

	public override void Execute()
	{
		if (owner.NPCHasDied)
		{
			fsm.SetState<DieState>();
			return;
		}
		if(owner.RunningOutOfLife && target.value != null)
		{
			if (Vector3.Distance(owner.transform.position, target.value.transform.position) < 3f)
			{
				fsm.SetState<FleeState>();
				return;
			}
		}
		if (target.value == null)
		{
			//if(LookOrIdle == 0) fsm.SetState<LookForExitState>();
			if (LookOrIdle == 0) fsm.SetState<EscapeState>();
			else fsm.SetState<IdleState>();

			return;
		}

		Vector3 dir = target.value.transform.position - owner.transform.position;
		owner.WP.Shoot(owner.transform.position + owner.transform.forward, dir);

	}

	public override void Init()
	{
		LookOrIdle = Random.Range(0, 1);
	}

	public override void LastExecute()
	{

	}
}
