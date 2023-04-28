﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	[SerializeField] float neighboursDistance = 10f;
	[SerializeField] LayerMask nodeLayer;
	[SerializeField] LayerMask obstableLayer;
	[SerializeField] public bool IsBlocked;
	[SerializeField] public float CurrentDistance = Mathf.Infinity;
	[SerializeField] Node[] possibleNodes;

	Dictionary<Node, float> neighbours = new Dictionary<Node, float>();

	public Dictionary<Node, float> Neighbours => neighbours;

	public Node PreviousNode { get; set; }
	
	public float H { get; set; }
	public float G { get; set; }
	public float F => H + G; 

	public Node[] PossibleNodes => possibleNodes;

	public LayerMask ObstableLayer => obstableLayer;

	void Awake()
    {
		G = Mathf.Infinity;
		H = Mathf.Infinity;
		GetNeighbours(); //agrego al diccionario los nodos que estan cerca
	}


	public void ResetNode()
	{
		G = Mathf.Infinity;
		H = Mathf.Infinity;
		CurrentDistance = Mathf.Infinity;
		PreviousNode = null;
	}

	public void GetNeighbours()
	{
		Collider[] neighboursColl = Physics.OverlapSphere(transform.position, neighboursDistance, nodeLayer);
		for (int i = 0; i < neighboursColl.Length; i++)
		{
			float distanceToNode = Vector3.Distance(transform.position, neighboursColl[i].transform.position);
			Vector3 dir = (neighboursColl[i].transform.position - transform.position).normalized;
			bool hit = Physics.Raycast(transform.position, dir,out RaycastHit hitInfo, distanceToNode, obstableLayer, QueryTriggerInteraction.Ignore);

			if(!hit && !IsBlocked) neighbours.Add(neighboursColl[i].GetComponent<Node>(), distanceToNode);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, neighboursDistance, nodeLayer);
		Gizmos.color = Color.blue;
		for (int i = 0; i < colliders.Length; i++)
		{
			RaycastHit hitInfo;
			Vector3 aux = colliders[i].gameObject.transform.position - transform.position;
			if (!Physics.Raycast(transform.position, aux.normalized, out hitInfo, aux.magnitude, obstableLayer, QueryTriggerInteraction.Ignore))
				Gizmos.DrawLine(transform.position, colliders[i].transform.position);
		}

	}
}
