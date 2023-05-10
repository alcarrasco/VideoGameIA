using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
	State[] states; //Creo un Array para guardar los estados del Enemy
	State currentState; //Este va a ser el estado actual, el cual se ejectura constantemente hasta que cambie de estado

	public Player player {get;set;}

	void Start()
	{
		player = null;
		states = GetComponents<State>(); // Agarro todos los estados que tenga el objeto
		for (int i = 0; i < states.Length; i++)
		{
			states[i].fsm = this;
			if (states[i].IsFirst) //Desde el editor, seteo el estado que va a ser el inicial
			{
				//guardo el estado inicial y lo arranco
				currentState = states[i]; 
				currentState.Init();
			}	
		}

	}

	private void Update()
	{
		//Durante el update del juego, la maquina de estados ejecutara constantemente el estado actual
		currentState.Excecute();
	}

	//Esta funcion cambiara al nuevo estado que necesite
	public void ChangeState(State newState)
	{
		if (newState != null)
		{
			currentState.End(); //Primero, ejecuto el end del estado actual
			currentState = newState; //Segundo, guardo el nuevo estado
			currentState.Init(); //Tercero, ejecturo el init del nuevo estado
		}
		else Debug.LogError("FSM.ChangeState(): No recibio el nuevo estado a cambiar.");
	}	
}
