using UnityEngine;
using System.Collections;

public class Ihateunityscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (false);
	}

	void OnEnable () {
		StateMachine.WaterTempleActivated += WaterTempleActive;
	}


	void OnDisable() {
		//StateMachine.WaterTempleActivated -= WaterTempleActive;
	}

	void WaterTempleActive () {
		this.gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
