using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class WaterPlayer : MonoBehaviour {

	Rigidbody Rbody;

	public static bool finished = false;
    public GameObject miniJug;
    //pos -232.5, -40, -298.96
	public Vector3 miniStartPos;
	public GameObject bigJug;
    // pos -22.5, -40, -298.96
	public Vector3 bigStartPos;
	
	RigidbodyFirstPersonController FPScontroller;
	bool showWater = false;

	public AudioClip PuzzleDone;
	AudioSource audioSound;

	GameObject Tap;
	GameObject Bucket;

	public GameObject CameraTest;

	GameObject clickedGmObj = null;
	GameObject targetGmObj = null;

	private float distance;
	Vector3 rayPoint;

    public GUISkin _guiSkin;
	public int miniJugWater = 0;
	public int bigJugWater = 0;
	
	int miniCapa = 3;
	int bigCapa = 5;

	void Awake () {
		Rbody = GetComponent<Rigidbody> ();
	}

	void Start () 
	{
		Tap = GameObject.Find("Tap");
		Bucket = GameObject.Find("Drain");
		FPScontroller = GetComponent<RigidbodyFirstPersonController> ();
		miniStartPos = miniJug.transform.position;
		bigStartPos = bigJug.transform.position;
		audioSound = GetComponent<AudioSource> ();

	}

	void Update()
	{

		
		if (Input.GetMouseButton (0)) 
		{
			clickedGmObj = GetClickedGameObject ();
			distance = Vector3.Distance(Camera.main.transform.position, CameraTest.transform.position);
			if (clickedGmObj != null) 
			{
				if (clickedGmObj.tag == "Jug") 
				{
					clickedGmObj.transform.position = rayPoint;
				}
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			if(clickedGmObj != null)
			{
				targetGmObj = GetRaycastHit (clickedGmObj);
			}

			if (clickedGmObj == bigJug)
			{
				if(targetGmObj == null)
					bigJug.transform.position = bigStartPos;
				//bucket
				if(targetGmObj == Bucket)
				{
					//Debug.Log("Empty Jug Big");
					bigJugWater = 0;
				}

				if(targetGmObj == Tap)
				{
					if(bigJugWater < bigCapa)
					{
						bigJugWater = bigCapa;
					
					} else
						Debug.Log("<color=red>Jug is full</color>");
				}
				//other jug
				if(targetGmObj == miniJug)
				{

					if(bigJugWater <= 0)
					{

					}
					if(miniJugWater <= miniCapa)
					{
						int miniTemp = miniJugWater; 
						int bigTemp = bigJugWater; 
						
						bigJugWater = bigTemp - (miniCapa - miniTemp); 
						miniJugWater = miniTemp + bigTemp; 
					}
					
					if(miniJugWater > miniCapa)
					{
						miniJugWater = miniCapa;

					}
					if(bigJugWater < 0)
					{
						bigJugWater = 0;
					}
				}
				bigJug.transform.position = bigStartPos;
			}
		
			if (clickedGmObj == miniJug)
			{
				if(targetGmObj == null)
					miniJug.transform.position = bigStartPos;

				if(targetGmObj == Bucket)
				{
					//Debug.Log("Empty Jug Small");
					miniJugWater= 0;
				}
				//tap
				if(targetGmObj == Tap)
				{
					if(miniJugWater < miniCapa)
					{
						miniJugWater = miniCapa;
						//Debug.Log("<color=green>MiniJug Water    </color>" + miniJugWater);
					}else
						Debug.Log("<color=red>Jug is full</color>");
				}
				//other jug
				if(targetGmObj == bigJug)
				{
					//Debug.Log("<color=green>Moving contents of Mini Jug to Big Jug </color>");
					if(miniJugWater <= 0)
					{
						//Debug.Log("<color=red>Jug is empty</color>");
					}
					if(bigJugWater <= bigCapa)
					{
						int bigTemp = bigJugWater; 
						int miniTemp = miniJugWater; 
						
						miniJugWater = miniTemp - (bigCapa - bigJugWater); 
						bigJugWater = bigTemp + miniTemp;
						
						if(bigJugWater > bigCapa)
						{
							bigJugWater = bigCapa;
							//Debug.Log("<color=red>Jug is full</color>");
						}
						if(miniJugWater < 0)
							miniJugWater = 0;
					}
				}
				miniJug.transform.position = miniStartPos;
			}
		}

		if(bigJugWater == 4) // IF PUZZLE IS FINISHED
		{
			finished= true;
			audioSound.PlayOneShot(PuzzleDone);
			this.enabled = false;
			//end puzzle, start water
		}
	}  
  
	void OnEnable () {
		this.transform.position = new Vector3 (-93, 23.4f, 195.6f);
       Quaternion targetRotation = Quaternion.Euler(new Vector3(358f, 31f, 0.15f));
       transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1);
        Rbody.constraints = RigidbodyConstraints.FreezeAll;
		Rbody.useGravity = false;
		//transform.LookAt (CameraTest.transform);
		UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = false;
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
	}

	void OnDisable () {
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

		UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;
	}

	GameObject GetClickedGameObject()
	{
		// Builds a ray from camera point of view to the mouse position
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		rayPoint = ray.GetPoint(distance);
		rayPoint.z = 147; // ??
		// Casts the ray and get the first game object hit
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			return hit.transform.gameObject;
		else
			return null;
	}

	GameObject GetRaycastHit(GameObject obj)
	{
		Vector3 direction = obj.transform.forward;
		//direction from camera to clickedobject
		//Vector3 direction = Vector3.Distance(obj.transform.position, Camera.main.transform.position);
		
		Ray ray = new Ray (obj.transform.position, direction);
		RaycastHit hitt;
		Debug.DrawRay (obj.transform.position, direction * 10f, Color.red, 1f);

		// Casts the ray and get the first game object hit
		if (Physics.Raycast (ray, out hitt, Mathf.Infinity))
			return hitt.transform.gameObject;
		else
			return null;
	}

	void OnGUI()
	{

        GUI.skin = _guiSkin;
        if (GUI.Button(new Rect(Screen.width / 10, 1, 150, 50), "Exit Puzzle")) this.enabled = false;
		GUI.color = Color.blue; 
        GUI.Label(new Rect(10, 10, 120, 20), "Small Jug: " + miniJugWater.ToString());
		GUI.Label(new Rect(10, 30, 60, 20), "Big Jug: " + bigJugWater.ToString());
	}
}