using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : PathFinding
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

		while (openNodes.Count >0)
		{
			Node currentNode = LookForLowerF();

			if (currentNode == endNode)
			{
				while (currentNode != null)
				{
					pathNodes.Push(currentNode);
					currentNode = currentNode.PreviousNode;
				}
				closedNodes.Add(endNode);
				break;
			}

			foreach (var node in currentNode.Neighbours)
			{
				var neighNode = node.Key;
				var neighDist = node.Value;

				if (closedNodes.Contains(neighNode) || neighNode.IsBlocked) continue;

				if(!openNodes.Contains(neighNode))
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
