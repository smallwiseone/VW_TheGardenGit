using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour {

	bool activated = false;
	Vector3 doorPos = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
		doorPos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//must go slower
		if (activated && (doorPos.y < 15)) {
			doorPos.y ++;
			this.transform.position = doorPos;

		}
	}

	void OnEnable ()
	{
		StateMachine.SunTempleActivated += SunTempleActive;
	}

	void OnDisable()
	{
		StateMachine.SunTempleActivated -= SunTempleActive;
	}

	void SunTempleActive()
	{
		activated = true;
	}
	
}
