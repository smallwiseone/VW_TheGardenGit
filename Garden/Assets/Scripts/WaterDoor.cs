using UnityEngine;
using System.Collections;

public class WaterDoor : MonoBehaviour {

	bool activated = false;
	Vector3 doorPos = new Vector3(-205,10,60);

	// Use this for initialization
	void Start () {
		this.transform.position = doorPos;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("update is running");
		if (activated && (transform.position.y < 40)) {
			
			doorPos.y++;
		}

	}

}
