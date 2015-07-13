using UnityEngine;
using System.Collections;

public class MirrorScript : MonoBehaviour {

	public bool activated; 


	public GameObject lightBeam ;
	GameObject NewLight;
	Quaternion rotationlight;

	public	GameObject _player;
	SunPlayer contr;
	int number = 10;

	void Start () {
	
		_player = GameObject.Find ("Player");
		contr = _player.GetComponent<SunPlayer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	

		if (activated == true) {
			if (transform.childCount == 2) {

				LightOn ();
			}
		}

		if (activated == false) {

//			if(lightBeam.activeSelf)
//			   {
//				//Destroy (NewLight);
//				contr.RaycastAll(number);
//				LightOff();
////				Debug.Log("calling raycastall from mirror  " + this.name);
//			}

			if (transform.childCount == 2) {
				//Destroy (NewLight);
				contr.RaycastAll(number);
				LightOff();
				//Debug.Log("calling raycastall from mirror  " + this.name);
			}
		}
	}

	public void ActivateMirrorScript ()
	{
		activated = true;
	}

	public void DeactivateMirrorScript()
	{
		if(this.tag == "StartMirror")
			return;
		//Debug.Log("Deactivating mirror from   " + this.name);
		activated = false;
		//print ("Deactivated");
	}

	public void DestroyAllLights(){
		//Destroy (NewLight);

		//Debug.Log("destroy all lights from  : " + this.name);
	}

	void LightOn()
	{
		lightBeam.SetActive(true);
	}

	public void LightOff()
	{
		//Debug.Log ("turning light off from  " + this.gameObject.name);
		lightBeam.SetActive(false);
	}
}
