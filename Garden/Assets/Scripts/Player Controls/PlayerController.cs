using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float maxVelocityChange;
	public bool grounded = true;
	public float jumpHeight;
	public Transform cam;
	private Rigidbody rbody;
	public Vector3 Gravity;
	// Use this for initialization
	void Awake ()
	{
		rbody = GetComponent<Rigidbody> ();
		Gravity = new Vector3 (0, -10f, 0);
		rbody.freezeRotation = true;

	}
	
	//Update is called once per frame
	void FixedUpdate () {
		//if (grounded) {
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");
			Vector3 MovementVector = new Vector3 (h, 0, v);
			MovementVector = cam.transform.TransformDirection (MovementVector);
			MovementVector *= speed;

			var vel = GetComponent<Rigidbody> ().velocity;

			var SubVel = (MovementVector - vel);

			SubVel.x = Mathf.Clamp (SubVel.x, -maxVelocityChange, maxVelocityChange);
			SubVel.z = Mathf.Clamp (SubVel.z, -maxVelocityChange, maxVelocityChange);
			SubVel.y = 0;

			rbody.AddForce (SubVel, ForceMode.VelocityChange);

		//}

		if (Input.GetButtonDown ("Jump") && grounded) {
			Debug.Log ("Jumping");
			rbody.AddForce (Vector3.up * jumpHeight, ForceMode.VelocityChange);

		}

	
		
	}

	void OnTriggerStay(Collider other){
		
		if (other.gameObject.tag == "Platform"){
			transform.parent = other.transform;
			
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Platform"){
			transform.parent = null;
			
		}
	}    

	void OnCollisionEnter(Collision theCollision){
		if(theCollision.gameObject.tag == "floor")
		{

			grounded = true;
		}
	}
	
	//consider when character is jumping .. it will exit collision.
	void OnCollisionExit(Collision theCollision){
		if(theCollision.gameObject.tag == "floor")
		{

			grounded = false;
		}
	}

}