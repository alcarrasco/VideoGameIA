using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThetaStar : PathFinding
{
	List<Node> openNodes = new List<Node>();

	public override void ExcecutePathFind(Node initialNode, Node endNode)
	{

		foreach (var node in closedNodes)
		{
			node.ResetNode();
		}
		foreach (var node in openNodes)
		{
			node.ResetNode();
		}

		closedNodes.Clear();
		openNodes.Clear();

		pathNodes = new Stack<Node>();

		openNodes.Add(initialNode);
		initialNode.G = 0;
		initialNode.PreviousNode = null;

		while (openNodes.Count > 0)
		{
			Node currentNode = LookForLowerF();

			if (currentNode == endNode)
			{

				while (currentNode != null)
				{
					pathNodes.Push(currentNode);

					Node previousNode = currentNode.PreviousNode;
					Node prevPrev;
					if (previousNode != null) prevPrev = previousNode.PreviousNode;
					else prevPrev = null;

					if (previousNode != null)
					{
						while (previousNode != null && currentNode != previousNode && prevPrev != null)
						{
							if (prevPrev != null)
							{
								Vector3 toPrevious = prevPrev.transform.position - currentNode.transform.position;
								if (!Physics.Raycast(currentNode.transform.position, toPrevious.normalized, out RaycastHit rayhit, toPrevious.magnitude, currentNode.ObstableLayer, QueryTriggerInteraction.Ignore))
								{
									previousNode = prevPrev;
									prevPrev = prevPrev.PreviousNode;
								}
								else prevPrev = prevPrev.PreviousNode;
							}
							else
							{
								currentNode = previousNode;
								previousNode = null;
							}
						}
						currentNode = previousNode;
					}
					else currentNode = null;

					//Vector3 toEnd = initialNode.transform.position - currentNode.transform.position;
					//if (!Physics.Raycast(currentNode.transform.position, toEnd.normalized, out RaycastHit rayhit, toEnd.magnitude, currentNode.ObstableLayer, QueryTriggerInteraction.Ignore)) currentNode = null;
					//else currentNode = currentNode.PreviousNode;
				}
				closedNodes.Add(endNode);
				break;
			}

			foreach (var node in currentNode.Neighbours)
			{
				var neighNode = node.Key;
				var neighDist = node.Value;

				if (closedNodes.Contains(neighNode) || neighNode.IsBlocked) continue;

				if (!openNodes.Contains(neighNode))
				{
					neighNode.H = HeuristicValue(neighNode, endNode);
					openNodes.Add(neighNode);
				}

				if (currentNode.G + neighDist < neighNode.G)
				{
					neighNode.G = currentNode.G + neighDist;
					neighNode.PreviousNode = currentNode;
				}
			}

			closedNodes.Add(currentNode);
			openNodes.Remove(currentNode);
		}
	}

	Node LookForLowerF()
	{
		var closerNode = openNodes[0];
		for (int i = 0; i < openNodes.Count; i++)
		{
			var tempNode = openNodes[i];
			if (tempNode.F < closerNode.F) closerNode = tempNode;
		}

		return closerNode;
	}

	float HeuristicValue(Node A, Node B)
	{
		return Vector3.Distance(A.transform.position, B.transform.position);
	}
}
