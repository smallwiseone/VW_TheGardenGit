using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class BeeAi : MonoBehaviour {

	//NodeWorld
	NodeWorld _world;
	Node currentNode;
	Node targetNode;
	bool atTarget = false;
	public float rotationSpeed = 2f;
	public float jeffSpeed = 1f;
	bool roaming = false;
	bool flying = false;


	bool waitingForPlayer = false;

	public GameObject playerSeat;
	GameObject _honey;
	GameObject playerObj;
	public GameObject FlyTrigger;
	public GameObject FlyTrigger2;

	bool startup = true;

	//float maxRange = 10.0f;
	float minRange = 2.0f;
	
	void Start () 
	{
		SetContext(GameObject.FindGameObjectWithTag("NodeWorld").GetComponent<NodeWorld>());
	}

	void Update () 
	{
		//put this in update function (not in start) to avoid ArgumentOutOfRange(Index)Error
		if(_world.nodes.Count > 0 && startup)
		{
			currentNode = _world.nodes[Random.Range(0,_world.nodes.Count -1)];
			
			Next(currentNode.connectedNodes[Random.Range(0, (currentNode.GetConnectionCount()))]);
			roaming = true;
			startup = false;
			Debug.Log("from Jeff  :" + roaming);
		}

		if(roaming)
			Roam();

		if (flying) {
			if(FlyTrigger2.activeSelf)
			{
				Fly(FlyTrigger2);
				playerObj.transform.position = playerSeat.transform.position;
			}
			if(!FlyTrigger2.activeSelf)
			{
				Fly(FlyTrigger);
				playerObj.transform.position = playerSeat.transform.position;
			}
		}

		//if (landing)
		//	Land ();

		if (waitingForPlayer) {
            roaming = false;
            if(Input.GetKey("e"))
			{
				
                StartCoroutine(WaitForPlayer());
                waitingForPlayer = false;
			}
		}
	}

	//Roam
	//--------------------------------------------------------------------------------------------------------------//
	public void LookAtSlowly (Vector3 targetPosition) {
		Quaternion neededRotation = Quaternion.LookRotation (targetPosition - this.transform.position);
		Quaternion interpolatedRot = Quaternion.Slerp (transform.rotation, neededRotation, Time.deltaTime * rotationSpeed);
		transform.rotation = interpolatedRot;
	}
	
	void Roam()
	{
		flying = false;
		
		LookAtSlowly (targetNode.worldPos);

		transform.Translate(Vector3.forward * (Time.deltaTime + 0.2f));

		atTarget = false;
		if(Vector3.Distance(transform.position,targetNode.worldPos) < minRange)
		{
			atTarget = true;
			currentNode = targetNode;
			roaming = false;
			Next(currentNode.connectedNodes[Random.Range(0, (currentNode.GetConnectionCount()))]);
			StartCoroutine(WaitAtFlower());

		}
	}

	void Next(Node _targetNode)
	{
		targetNode = _targetNode;
	}

	public void SetContext(NodeWorld world)
	{
		_world = world;
	}

	IEnumerator WaitAtFlower() 
	{
		yield return new WaitForSeconds(3);
		roaming = true;
	}

	IEnumerator WaitForPlayer() 
	{
        
		yield return new WaitForSeconds(1);
	
        FlyTrigger2.SetActive (true);
		flying = true;
       
    }

	void OnTriggerStay (Collider other) 
	{
		if (other.gameObject.name == "Honey") {
			LookAtSlowly(playerObj.transform.position);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Honey") {

            if (DiaPlayer.finishedTalk1)
            {
                _honey = other.gameObject;
                roaming = false;

                waitingForPlayer = true;
                playerObj = other.transform.parent.gameObject;
            }
		} 

		if (other.gameObject == FlyTrigger) {
			playerObj.GetComponent<Rigidbody>().useGravity = true;
			Debug.Log("flytriggeractive");
			flying = false;
			waitingForPlayer = false;
			Next (_world.nodes.ElementAt (4));
			StartCoroutine(WaitAtFlower());
			//set new targetnode

		}

		if (other.gameObject == FlyTrigger2) {
			Fly(FlyTrigger);
			other.gameObject.SetActive(false);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "Honey")
		{
			waitingForPlayer = false;
			roaming = true;
			Next(currentNode.connectedNodes[Random.Range(0, (currentNode.GetConnectionCount()))]);
		}
	}

	void Fly(GameObject trigger)
		//move to suntemple drop plyer
	{
		if (transform.position.y <= 30) {
			transform.Translate(Vector3.up * (Time.deltaTime + 0.1f));
	    }
		LookAtSlowly(trigger.transform.position);
		transform.Translate(Vector3.forward * (Time.deltaTime + jeffSpeed));
        playerObj.GetComponent<Rigidbody>().useGravity = false;
        _honey.SetActive (false);
		
//      needs to be fixed
//		if(Vector3.Distance(transform.position,trigger.transform.position) < 5)
//		{
//			return;
//			flying = false;
//			Debug.Log("returning");
//		}
	}

//	void Land()
//	{
//		if (transform.position.y > 8) {
//			transform.Translate(Vector3.down * (Time.deltaTime + 0.1f));
//		}
//		if (transform.position.y <= 8 && _honey.activeSelf == true) {
//			waitingForPlayer = true;
//			//_honey.SetActive (false);
//		}
//	}

	void OnGUI()
	{
		if(waitingForPlayer)
			GUI.Box(new Rect (Screen.width/2, Screen.height/2, 100,50), "Press E to Fly");
	}
}
