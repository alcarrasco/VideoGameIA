using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStimulusState : State<NPC>
{
	BlackboardEntry<GameObject> target;

	public GoToStimulusState(NPC owner, FSM<NPC> stateMachine) : base(owner, stateMachine)
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
		if (target.value != null)
		{
			fsm.SetState<AttackState>();
			return;
		}
		if(owner.Stimulus.value == Vector3.zero)
		{
			//fsm.SetState<LookForExitState>();
			fsm.SetState<EscapeState>();
			return;
		}
			
		owner.transform.forward = Vector3.Lerp(owner.transform.forward,(owner.Stimulus.value - owner.transform.position).normalized, Time.deltaTime*5);

	}

	public override void Init()
	{

	}

	public override void LastExecute()
	{

	}
}
