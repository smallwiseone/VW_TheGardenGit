using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class StateMachine : MonoBehaviour {
	public delegate void StateChanger();
	public static event StateChanger WaterTempleActivated;
	public static event StateChanger SunTempleActivated;
	public static event StateChanger TrashTempleActivated;
	public static event StateChanger ArrowChange;
	MouseLook mouseLookComponent;
	Rigidbody Rbody;

    public GUISkin _guiStyle;

    bool showSun = false;
	bool showWater = false;
	RigidbodyFirstPersonController FPScontroller;
	//puzzles___________________

	public GameObject cameraTest;
	
	void Start () {
		Rbody = GetComponent <Rigidbody> ();
		FPScontroller = GetComponent<RigidbodyFirstPersonController> ();
		mouseLookComponent = GetComponent<RigidbodyFirstPersonController> ().GetComponent<MouseLook>();
	}
	//_______________________________

	//BugList:
	//DIA
	//jeff - DONE
    //add pause

	//TODO
	//done//change player controls with button for DIA and BeeRiding
	//done//add water to water
	//done//change terrains
	//change SKYBOX
	//-----//get creatives to make an arrow model - add arrow on top of King's head - DONE

	// jeff - after drop off, go to certain target node first1111 - 
	//fix jeff - DONE
	//-jeff turn on after king bee talk - DONE
	//-cant arive at target node after.somethig..happens
	//-- add black sphere to beehive, put node in beehive, so it looks like Jeff goes inside

	//Add graphics to gui.box


	//assets
	//platforms - DONE
	//lever/switch/button - DONE
	//clean up code
	//add cool lights

	//make them draw bugs

	//add rain - NOPE


	//Add on Update if (keycode.something) : quit puzzle
	// Fixed player positioning when triggering dialogue/puzzle
	// (Freeze position + Rotation when triggered, exit when puzzle finished || dialogue is ended.
   
    bool pause = false;
    void Pause(bool paused) {
        
        if (paused && Time.timeScale == 1) {
            
            Time.timeScale = 0;
        }
        else if (!paused && Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        
    }

    
	void Update()
	{
        
        if (Input.GetKeyDown(KeyCode.P)){
            pause = !pause;
            Pause(pause);
        }
       
		if (showWater) {
			if (Input.GetMouseButtonDown(0)) {
				showWater = false;
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
        
			
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Trash" && TrashButton.buttonHasBeenPressedOkay) {
			if ( TrashTempleActivated != null) {
				TrashTempleActivated();
				Debug.Log("Trash Activated");
			}
		}

		if (other.gameObject.tag == "Sun" && SunPlayer.finished) {
			if (SunTempleActivated != null) {
				SunTempleActivated();
				if (GameObject.Find ("Directional Light").GetComponent<Light>().intensity < 1.5f)
				GameObject.Find ("Directional Light").GetComponent<Light>().intensity += 1;
				Debug.Log (GetComponent<Light>().intensity);	
			}
		}

		if (other.gameObject.tag == "Water" && WaterPlayer.finished) {
			if (WaterTempleActivated != null) {
				WaterTempleActivated();
				Debug.Log("Water Activated");
			}
		}

		
		if (other.gameObject.name == "WPTrigger" && !WaterPlayer.finished) {
			showWater = true;
			GetComponent<WaterPlayer>().enabled = true; 
		}

		if (other.gameObject.name == "SPTrigger" && !SunPlayer.finished) {
            showSun = true;
			GetComponent<SunPlayer>().enabled = true; 

		}

	}

    
	void OnGUI()
	{
        GUI.skin = _guiStyle;
      
        if (pause) 
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 150, 50), "Press P to Resume"); 

		if(showWater)
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,500,200),"You have a three and a five litre water container \n You must fill the containers using the tap,\n and empty them using the drain \n You must measure out exactly four litres of water \n You can click and drag the containers onto each other, the tap, and the drain");
        
       
    }


}
