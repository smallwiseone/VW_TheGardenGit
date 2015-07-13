using UnityEngine;
using System.Collections;

public class WaterJugs : MonoBehaviour {

	int _miniJugWater = 0;
	int _bigJugWater = 0;
	Vector3 miniPos;
	Vector3 bigPos;
	Vector3 miniPosScale;
	Vector3 bigPosScale;
	// Use this for initialization
	void Start () {

	
		if (this.gameObject.name == "WaterBig") {
			bigPos = this.transform.position;
			bigPosScale = this.transform.localScale;
		} else {
			miniPos= this.transform.position;
			miniPosScale = this.transform.localScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		_miniJugWater = GameObject.FindGameObjectWithTag ("Player").GetComponent<WaterPlayer> ().miniJugWater;
		_bigJugWater = GameObject.FindGameObjectWithTag ("Player").GetComponent<WaterPlayer> ().bigJugWater;
		if (this.name == "WaterMini")
			switchPosMini ();

		if (this.name == "WaterBig")
			switchPosBig ();
	}

	void switchPosMini () 
	{
		switch (_miniJugWater) {
		case 0:
			miniPosScale = new Vector3 (0f,0f,0f);
			this.transform.localScale = miniPosScale;
			break;
		case 1:
			miniPos = new Vector3 (-2.4f, 4.35f, 0f);
			miniPosScale = new Vector3 (16f,2.4f,10.2f);
			this.transform.localPosition = miniPos;
			this.transform.localScale = miniPosScale;
			break;
		case 2:
			miniPos = new Vector3 (-2.5f, 5.8f, 0);
			miniPosScale = new Vector3 (16f,3.8f,10.2f);
			this.transform.localPosition = miniPos;
			this.transform.localScale = miniPosScale;
			break;
		case 3:
			miniPos = new Vector3 (-2.4f, 7.55f, 0);
			miniPosScale = new Vector3 (16,5.6f,10.2f);
			this.transform.localPosition = miniPos;
			this.transform.localScale = miniPosScale;
			break;
		
		
		}
	}

	void switchPosBig () 
	{
		switch (_bigJugWater) {
		case 0:
			bigPosScale = new Vector3(0f,0f,0f);
			this.transform.localScale = miniPosScale;
			break;
		case 1 :
			bigPos = new Vector3 (0f, 3.7f, 0f);
			bigPosScale = new Vector3 (16.5f,1.8f,10.2f);
			this.transform.localPosition = bigPos;
			this.transform.localScale = bigPosScale;
			break;
		case 2:
			bigPos = new Vector3 (0f, 5.0f, 0f);
			bigPosScale = new Vector3 (16.5f,3.15f,10.2f);
			this.transform.localPosition = bigPos;
			this.transform.localScale = bigPosScale;
			break;
		case 3:
			bigPos = new Vector3 (0f, 6.25f, 0f);
			bigPosScale = new Vector3 (16.5f,4.65f,10.2f);
			this.transform.localPosition = bigPos;
			this.transform.localScale = bigPosScale;
			break;
		case 4:
			bigPos = new Vector3 (0f, 7.2f, 0f);
			bigPosScale = new Vector3 (16.5f,5.8f,10.2f);
			this.transform.localPosition = bigPos;
			this.transform.localScale = bigPosScale;
			break;
		case 5:
			bigPos = new Vector3 (0f, 8.65f, 0f);
			bigPosScale = new Vector3 (16.5f,6.66f,10.2f);
			this.transform.localPosition = bigPos;
			this.transform.localScale = bigPosScale;
			break;
		}
	}

	//find<compent>player(waterscript).minijugwater


	//if this.name == mini
	// miniejugwater is
	//1 - change position
	
}
