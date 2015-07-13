using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class SunPlayer : MonoBehaviour {
    //pos  3.16, 15.73,-109
    //rot 0.8, 140, 359


	public static bool finished = false;

	private GameObject clickedGmObj = null;
	private GameObject targetGmObj = null;
    public GameObject LookAtThis;
	public GameObject lightBeam ;
	Quaternion rotationlight;

	Vector3 direction;

    public GUISkin _guiSkin; 
	private RigidbodyFirstPersonController FPSController;
	private Rigidbody Rbody;
	public List<GameObject> mirrors = new List<GameObject>();
	MirrorScript _mirrorScript;
	GameObject step;

	public AudioClip PuzzleDone;
	private AudioSource audioSound;
	
	// Use this for initialization
	void Awake () 
	{
		FPSController = GetComponent<RigidbodyFirstPersonController> ();
		Rbody =  GetComponent <Rigidbody> ();
		audioSound = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
	if (showInfo)
        if (Input.GetMouseButtonDown(0)) {
            showInfo = false;

        }
		if (Input.GetMouseButtonDown (0)) 
		{
			Debug.Log ("MouseClick");
			clickedGmObj = GetClickedGameObject ();

			if (clickedGmObj != null) 
			{
				
				if (clickedGmObj.tag == "Mirror" || clickedGmObj.tag == "StartMirror") 
				{

					//make it rotate
					Debug.Log("helloworld");
					clickedGmObj.transform.Rotate (0, 120, 0);

					_mirrorScript = clickedGmObj.GetComponent<MirrorScript>();

					if(clickedGmObj.tag == "StartMirror" || _mirrorScript.activated)
					{
						targetGmObj = GetRaycastHit (clickedGmObj);
						//Debug.Log("finding target gameobj  :" + targetGmObj);
						
						if(targetGmObj == null)
							Debug.Log("Clicked Game Object's Raycast Hits nothing");
						//bucket
						if(targetGmObj.tag == "Mirror")
						{
//							Debug.Log(clickedGmObj.name + "  is hitting  " + targetGmObj.name);
							rotationlight.eulerAngles = targetGmObj.transform.forward;

							targetGmObj.GetComponent<MirrorScript> ().ActivateMirrorScript ();

							//Debug.Log("mirrors0   " + mirrors[0].name);
							mirrors.Add(targetGmObj);
							step = targetGmObj;
							Debug.Log("clickedgameobject   :" + clickedGmObj + "   Target gameobj   :" + targetGmObj  + "step   : " + step.name);
						}

						if(targetGmObj.name == "EndCube") //If puzzle is finished!
						{
							Debug.Log("Sun Puzzle Finished");
							finished = true;
                            audioSound.PlayOneShot(PuzzleDone);
                            this.enabled = false;
						}

						if(targetGmObj.tag == "Bottle" && clickedGmObj != step)
						{
							
							step.GetComponent<MirrorScript> ().DeactivateMirrorScript ();
							Debug.Log("resetting mirrors from   " + step.name);
						}

						if(targetGmObj.tag == "StartMirror")
						{
							//hello
						}
					}
				}
			}
		}
	}


	//Code transported from the state machine! (I thought it makes much more sense for it to be here....
	void OnEnable () {
      
		this.transform.position = new Vector3 (8.1f, 14.7f, -117f);
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0.7f, 141f, 1.86f));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
      
        Rbody.constraints = RigidbodyConstraints.FreezeAll;
        Rbody.useGravity = false;
        UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = false;
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
		
       
        
	}
	//CANT SET PROPER LOOKAT POSITION !!!!! CANT CHANGE ONE of the DIMENSIONs OF THE CAMERA ROTATION LOOK!!!!!
	void OnDisable () {

		Rbody.useGravity = true;
		Rbody.constraints = RigidbodyConstraints.FreezeRotation;
		FPSController.mouseLook.MinimumX = -45;
		FPSController.mouseLook.MaximumX = 90;
		//
		UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;
	}
	// who sucks mammooth balls?? unity ass-ets! 

	public void RaycastAll(int n)
	{
		for (int i = n-1; i < mirrors.Count; i++) 
		{
			Debug.Log("mirros destroyed  : " + mirrors[i].name);
			mirrors[i].GetComponent<MirrorScript>().DestroyAllLights();
			mirrors[i].GetComponent<MirrorScript>().LightOff();
		}

	}

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

    
    bool showInfo = true;
   
    void OnGUI() {
        GUI.skin = _guiSkin;
        if (GUI.Button(new Rect(Screen.width / 10, 1, 150, 50), "Exit Puzzle")) this.enabled = false;

        if (GUI.Button(new Rect(Screen.width / 2, 1, 150, 50), "Show it again!")) showInfo = true;
        
        if (showInfo)
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 500, 200), "Can you align these mirrors for me please? \n I'm too old and my back hurts...");
    }
	
    GameObject GetRaycastHit(GameObject obj)
	{
		direction = obj.transform.forward;
		Ray ray = new Ray (obj.transform.position, direction);
		RaycastHit hitt;
		Debug.DrawRay (obj.transform.position, direction * 20f, Color.red, 10f);

		// Casts the ray and get the first game object hit
		if (Physics.Raycast (ray, out hitt, Mathf.Infinity))
			return hitt.transform.gameObject;
		else
			return null;
	}


}
