using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviors
{
	protected override void Move()
	{
		if (destination != null)
		{
			direction = (destination.position - transform.position).normalized;

			transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotSpeed);
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
	}
}
