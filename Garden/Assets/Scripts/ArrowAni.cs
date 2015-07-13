using UnityEngine;
using System.Collections;

public class ArrowAni : MonoBehaviour {

	GameObject HoverOverThis;
	Vector3 arrowPos;
	float moveSpeed = 5f;
	
	// Use this for initialization
	void Start () {
		arrowPos = this.transform.position;
	}
	
	void Update ()
	{
		this.transform.position = new Vector3 (arrowPos.x,  arrowPos.y + Mathf.Sin (Time.time * moveSpeed), arrowPos.z);

		if (DiaPlayer.ArrowEnabled) {
            GetComponent<Renderer>().enabled = true;
		} else {
            GetComponent<Renderer>().enabled = false;
		}

	}
}
