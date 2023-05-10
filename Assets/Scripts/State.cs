using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
	[SerializeField] protected bool isFirst; //Este booleano se usa para elegir el estado que sera el inicial
	public FSM fsm {get;set;} //Guardo la referencia a la maquina de estado

	public abstract void Init(); //Cuando arranque el estado, primero ejecutara esta funcion
	public abstract void Excecute (); //Mientras este activo el estado, se ejecutara esta funcion
	public abstract void End(); //Cuando termine el estado, se ejecutara esta funcion

	public bool IsFirst => isFirst;
}
