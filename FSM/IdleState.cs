using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<NPC>
{
	BlackboardEntry<GameObject> target;
	float elapsedTime;
	int leftOrRight;
	int idleTime;

	public IdleState(NPC owner, FSM<NPC> stateMachine) : base(owner, stateMachine)
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
		if (owner.Stimulus.value != Vector3.zero)
		{
			fsm.SetState<GoToStimulusState>();
			return;
		}
		if (elapsedTime >= idleTime)
		{
			//fsm.SetState<LookForExitState>();
			fsm.SetState<EscapeState>();
			return;
		}

		if(leftOrRight == 0) owner.transform.forward = Vector3.Lerp(owner.transform.forward, owner.transform.right, Time.deltaTime);
		else owner.transform.forward = Vector3.Lerp(owner.transform.forward, -owner.transform.right, Time.deltaTime);

		elapsedTime += Time.deltaTime;
	}

	public override void Init()
	{
		elapsedTime = 0;
		idleTime = Random.Range(2, 3);
		leftOrRight = Random.Range(0, 1);


	}

	public override void LastExecute()
	{
		
	}
}
