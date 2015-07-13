using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {


	public Vector3 worldPos;
	public string name;
	public List<Node> connectedNodes = new List<Node>();

	// Use this for initialization
	void Start () {
	
	}
	
	public Node(Vector3 _worldPos, string _name)
	{
		worldPos = _worldPos;
		name = _name;
	}

	public void AddConnection(Node other)
	{
		connectedNodes.Add(other);
		other.connectedNodes.Add(this);
	}

	public int GetConnectionCount()
	{
		return(connectedNodes.Count);
	}
}
