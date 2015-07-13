using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeWorld : MonoBehaviour {

	public List<Node> nodes = new List<Node>();

    
	public GameObject node_0;
	public GameObject node_1;
	public GameObject node_2;
	public GameObject node_3;
	public GameObject node_4;
	public GameObject node_5;
	public GameObject node_6;

	// Use this for initialization
	void Start () {
		AddNode();

		AddConnection(nodes.IndexOf(nodes[0]), nodes.IndexOf(nodes[1]));

		AddConnection(nodes.IndexOf(nodes[0]), nodes.IndexOf(nodes[3]));
		AddConnection(nodes.IndexOf(nodes[0]), nodes.IndexOf(nodes[5]));
		AddConnection(nodes.IndexOf(nodes[0]), nodes.IndexOf(nodes[6]));
		AddConnection(nodes.IndexOf(nodes[1]), nodes.IndexOf(nodes[2]));

		AddConnection(nodes.IndexOf(nodes[1]), nodes.IndexOf(nodes[5]));
	
		AddConnection(nodes.IndexOf(nodes[2]), nodes.IndexOf(nodes[4]));
	
		AddConnection(nodes.IndexOf(nodes[2]), nodes.IndexOf(nodes[6]));
		AddConnection(nodes.IndexOf(nodes[3]), nodes.IndexOf(nodes[4]));
	
		AddConnection(nodes.IndexOf(nodes[4]), nodes.IndexOf(nodes[6]));
		AddConnection(nodes.IndexOf(nodes[5]), nodes.IndexOf(nodes[6]));
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void AddNode()
	{
		
		nodes.Add (new Node(node_0.transform.position, "a" ));
		nodes.Add (new Node(node_1.transform.position, "b") );
		nodes.Add (new Node(node_2.transform.position, "c") );
        //jeffs node
		nodes.Add( new Node(node_3.transform.position, "d") );
		nodes.Add( new Node(node_4.transform.position, "e") );
		nodes.Add( new Node(node_5.transform.position, "f") );
		nodes.Add( new Node(node_6.transform.position, "g") );
		
		
//		foreach(Node n in nodes)
//		{
//			BoxCollider boxColl;
//
//			GameObject nodeObject = new GameObject(n.name);
//			nodeObject.tag = "node";
//			
//			nodeObject.transform.position = n.worldPos;
//			
//			boxColl = nodeObject.AddComponent<BoxCollider>();
//			boxColl.size = new Vector3(2f, 2f, 2f);
//		}
	}

	void AddConnection(int a, int b)
	{
		nodes[a].AddConnection(nodes[b]);
	}


	void OnDrawGizmos()
	{
		Vector3 cubeSize = new Vector3( 2.5f, 2.5f, 2.5f );
		
		if(nodes != null)
		{
			foreach( Node n in nodes )
			{
				Gizmos.color = Color.red;

				Gizmos.DrawWireCube(n.worldPos,cubeSize);
				Gizmos.DrawIcon(n.worldPos, n.name);
				
				foreach( Node c in n.connectedNodes )
				{
					Gizmos.color = Color.white;
					//					if(drawnPath != null)
					//					{
					//						if(drawnPath.Contains(n))
					//						{
					//							Gizmos.color = Color.black;
					//						}
					//					}
					Gizmos.DrawLine(n.worldPos, c.worldPos);
				}
			}
		}
	}
}
