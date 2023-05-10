using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
	public override void End()
	{

	}

	public override void Excecute()
	{
		//Patrullar entre waypoins o nodos hasta cierto punto (se puede controlar por tiempo o por cantidad de nodos recorridos) y despues ir a iddle
		Debug.Log("Patrolling...");
	}

	public override void Init()
	{

	}

}
