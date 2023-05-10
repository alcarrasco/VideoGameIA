using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
	public override void End()
	{
	}

	public override void Excecute()
	{
		//Moverse o disparar o hacer el ataque contra el enemigo
		Debug.Log("Attacking...");
	}

	public override void Init()
	{

	}

}
