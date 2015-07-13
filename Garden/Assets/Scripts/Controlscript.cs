using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controlscript : MonoBehaviour {
	RaycastHit hitt;

	GameObject clickedGmObj = null;
	GameObject targetGmObj = null;
	public GameObject lightBowl ;
	Quaternion rotationlight;
//	Vector3 fwd = transform.TransformDirection(Vector3.forward);

	Vector3 c1;
	Vector3 c2;

	public List<GameObject> mirrors = new List<GameObject>();

	GameObject CheckTarget;
	GameObject NewLight = null;
	GameObject test;
	GameObject step;
	MirrorScript mirrorScript;

	void Start () 
	{

	}



	void Update () {

	
		if (Input.GetMouseButtonDown (0)) {

			clickedGmObj = GetClickedGameObject ();

			if (clickedGmObj.tag == "Mirror" || clickedGmObj.tag == "StartMirror") {
				clickedGmObj.transform.Rotate (0, 120, 0);//rotate all  mirrors
			
				mirrorScript = clickedGmObj.GetComponent<MirrorScript>();
				mirrorScript.activated = true;
				if (mirrorScript.activated == true || clickedGmObj.tag == "StartMirror"){
				
					targetGmObj = GetRaycastHit (clickedGmObj);
					Debug.Log("targetobj    "+targetGmObj.name);

				}
			

			//	print (targetGmObj);
			
				if (targetGmObj != null) {
					if (targetGmObj.tag == "Mirror") {

					
						rotationlight.eulerAngles = targetGmObj.transform.forward;
						//	print (targetGmObj.name);
						targetGmObj.GetComponent<MirrorScript> ().ActivateMirrorScript ();
						step = targetGmObj;
						Debug.Log("step  " + step.name);
					}
				}
			

	
			}

			if (targetGmObj.tag == "Bottle" && clickedGmObj != step) 
			{
			//	print (targetGmObj.name + step);
				Debug.Log("Hit wall, resetting mirrors");
				step.GetComponent<MirrorScript> ().DeactivateMirrorScript ();
			}
	
		}
	}



	
	 void CreateLight(GameObject obj){

			GameObject LB = 	GameObject.Instantiate (lightBowl, obj.transform.position, rotationlight) as GameObject;
			LB.transform.Rotate(90,0,0);
			LB.transform.parent = obj.transform;
			LB.transform.position = new Vector3 (obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 2);
			NewLight = LB;
			
		}


	
	public void RaycastAll(int n)
	{

		for (int g = n; g < mirrors.Count; g++) {
		
			mirrors[g].GetComponent<MirrorScript>().DestroyAllLights();

		
		}
	}
	

	GameObject GetRaycastHit(GameObject obj)
	{
		Vector3 direction = obj.transform.forward;

		Ray ray = new Ray (obj.transform.position, direction);
		RaycastHit hitt;
		Debug.DrawRay (obj.transform.position, direction * 40f, Color.red, 1f);

		// Casts the ray and get the first game object hit
		if (Physics.Raycast (ray, out hitt, 20.0f))
			return hitt.transform.gameObject;
		else
			return null;
	}

//	GameObject GetRaycastHitBackwards(GameObject obj)
//	{
//		Vector3 direction = -obj.transform.forward;
//		
//		Ray ray = new Ray (obj.transform.position, direction);
//		Debug.DrawRay (obj.transform.position, direction, Color.yellow, 1f);
//		
//		if (Physics.Raycast (ray, out hitt, 10.0f))
//			return hitt.transform.gameObject;
//		else
//			return null;
//	}

	GameObject GetClickedGameObject()
	{
		// Builds a ray from camera point of view to the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		// Casts the ray and get the first game object hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			return hit.transform.gameObject;
		else
			return null;
	}
}





/*
			if (clickedGmObj != null) {
				//Debug.Log (clickedGmObj.name);
				clickedGmObj.transform.Rotate (0, 120, 0);

				
				Vector3 direction = clickedGmObj.transform.forward;

				Ray ray = new Ray (clickedGmObj.transform.position, direction);
				Debug.DrawRay(clickedGmObj.transform.position, direction * 10f, Color.red, 1f);



				//c1 = clickedGmObj.transform.position;
			//	c2 = clickedGmObj.transform.position + direction * 10;



				if (Physics.Raycast (ray, out hitt, 10.0f)) {
					
				
					Debug.Log (hitt.transform.name);
					if (hitt.transform.tag == "Mirror"){

					
*/


//display = true;




//Debug.DrawLine (c1,c2 , Color.green);

