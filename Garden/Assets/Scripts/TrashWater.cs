using UnityEngine;
using System.Collections;

public class TrashWater : MonoBehaviour {

	Vector3 trashPos = new Vector3 (0, 0, 0);

	void Start () {
		//position bottom of lake
		//Debug.Log (this.name + "thisTrans" + this.transform.position);
		trashPos = this.transform.position;
		trashPos.y = -17;
		this.transform.position = trashPos;
	}
	
	void OnEnable () {
		StateMachine.WaterTempleActivated += WaterTempleActive;
	}
	
	void WaterTempleActive () {
		trashPos.y = 0;
		this.transform.position = trashPos;
	}


}
