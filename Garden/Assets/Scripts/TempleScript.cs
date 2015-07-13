using UnityEngine;
using System.Collections;

public class TempleScript : MonoBehaviour {


	public bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("from temple" + triggered);
	}

	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			triggered = true;
			Debug.Log ("triggered");
		}
	}
}
