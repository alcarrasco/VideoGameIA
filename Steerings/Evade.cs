using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : SteeringBehaviors
{

	[SerializeField] float timeOfPrediction;

	protected override void Move()
	{
		Vector3 targetPredictedPosition = destination.position + destination.forward * destination.gameObject.GetComponent<UnitMovement>().Vel * timeOfPrediction;

		direction = (targetPredictedPosition - transform.position).normalized;

		transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotSpeed);
		transform.position -= transform.forward * speed * Time.deltaTime;
	}

}
