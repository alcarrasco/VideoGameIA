using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathFinding
{
	protected List<Node> closedNodes = new List<Node>();
	protected Stack<Node> pathNodes;
	public Stack<Node> PathNodes
	{ 
		get => pathNodes;
		set => pathNodes = value;
	}

	public abstract void ExcecutePathFind(Node initialNode, Node destinyNode);
}
