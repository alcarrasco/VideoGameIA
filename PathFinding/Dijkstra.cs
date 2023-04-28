using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra : PathFinding
{
	Queue<Node> openNodes = new Queue<Node>();

	public override void ExcecutePathFind(Node initialNode, Node destinyNode)
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
		openNodes.Enqueue(initialNode);
		initialNode.CurrentDistance = 0;
		initialNode.PreviousNode = null;

		while(openNodes.Count > 0)
		{
			Node currentNode = openNodes.Dequeue();

			if(currentNode == destinyNode)
			{
				while(currentNode != null)
				{
					pathNodes.Push(currentNode);
					currentNode = currentNode.PreviousNode;
				}
				closedNodes.Add(destinyNode);
				//return pathNodes;

				break;
			}

			foreach (var neighbour in currentNode.Neighbours)
			{
				var neighbourNode = neighbour.Key;
				var neighbourCost = neighbour.Value;

				if(closedNodes.Contains(neighbourNode) || neighbourNode.IsBlocked) continue;

				if (!openNodes.Contains(neighbourNode)) openNodes.Enqueue(neighbourNode);

				var possibleBetterCost = currentNode.CurrentDistance + neighbourCost;
				if (possibleBetterCost < neighbourNode.CurrentDistance)
				{
					neighbourNode.CurrentDistance = possibleBetterCost;
					neighbourNode.PreviousNode = currentNode;
				}

			}

			closedNodes.Add(currentNode);

		}

	}
}
