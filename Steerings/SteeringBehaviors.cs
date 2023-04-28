using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehaviors : MonoBehaviour
{

	[SerializeField] protected float speed;
	[SerializeField] protected float rotSpeed;
	[SerializeField] protected Transform destination;
	protected Vector3 direction;

	bool isMoving;

	public Transform Destination
	{
		get => destination;
		set
		{
			destination = value;
			if (destination != null) isMoving = true;
			else isMoving = false;
		}
	}

	public bool IsMoving => isMoving;

	protected abstract void Move();

	protected virtual void Update()
	{
		Move();
	}

}
