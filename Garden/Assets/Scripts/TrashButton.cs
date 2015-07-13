using UnityEngine;
using System.Collections;

public class TrashButton : MonoBehaviour {

	bool playerIsNear = false;

	public static bool buttonHasBeenPressedOkay = false;

	public AudioClip PuzzleDone;
	AudioSource audioSound;

	// Use this for initialization
	void Start () {
		//buttonPos = this.transform.position;
		audioSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	bool move = false;

	void Update () {
	
		if (playerIsNear && Input.GetKeyDown ("e")) {
			this.transform.localPosition = new Vector3 (0, -3, 0);
			move = true;
			audioSound.PlayOneShot(PuzzleDone);
			buttonHasBeenPressedOkay = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && !buttonHasBeenPressedOkay) {
			playerIsNear = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			playerIsNear = false;
		}
	}

	void OnGUI()
	{
		if (playerIsNear)
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 100, 50), "Press 'E' to Push");
			
		
	}	
}
