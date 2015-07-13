using UnityEngine;
using System.Collections;

public class RiverRespawnAfter : MonoBehaviour {

	public AudioClip fallingSound;
	AudioSource audioSound;


	void Start()
	{
		audioSound = GetComponent<AudioSource> ();
	}



	IEnumerator WaitForMe (GameObject player) {
		yield return new WaitForSeconds(1.5f);
		player.transform.position = new Vector3 (31, 6f, 0);
	}
	
	void OnTriggerEnter (Collider other) {
		
		if (other.tag == "Player") {
			StartCoroutine (WaitForMe (other.gameObject));
			audioSound.PlayOneShot(fallingSound);
		}
	}
}
