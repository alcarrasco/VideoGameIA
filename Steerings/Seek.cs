using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviors
{
	protected override void Move()
	{
		if (destination != null)
		{
			direction = (destination.position - transform.position).normalized;

			Vector3 lerp = Vector3.Lerp(transform.forward, direction, Time.deltaTime * rotSpeed);


			float angle = Vector3.Angle(lerp, direction);

			if (angle < 30)
			{
				transform.forward = lerp;
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			else
			{
				transform.forward = lerp;
			}

		}
	}
}
