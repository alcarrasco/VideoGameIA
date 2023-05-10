using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iddle : State
{
	[SerializeField] float idleTime = 5f;
	float timeInIdle;
	Patrol patrolState;
	Attack attackState;

	private void Start()
	{
		patrolState = GetComponent<Patrol>();
		attackState = GetComponent<Attack>();
	}
	public override void Init()
	{
		timeInIdle = 0; //Inicializo el contador del tiempo
	}

	public override void Excecute()
	{
		timeInIdle += Time.deltaTime; //voy sumando todo el tiempo transcurrido
		if(fsm.player != null) //Si el enemigo ve al personaje, cambia al estado atacar
		{
			fsm.ChangeState(attackState);
			return;
		}
		if(timeInIdle >= idleTime) //Si llega al tiempo de idle deseado, cambio al estado patrullar
		{
			fsm.ChangeState(patrolState);
			return;
		}

	}
	public override void End()
	{

	}

}
