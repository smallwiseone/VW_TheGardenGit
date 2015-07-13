using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DiaPlayer : MonoBehaviour {

	public int firstWord = 0;
	public static bool ArrowEnabled = true;
    public static bool finishedTalk1;
    private bool inDia = false;
	private bool talkTrigger = false;
	//private bool AllDialoguesAreBelongToUs = false;
	private string[] DialogTrack;

    public GUISkin _guiSkin;

	Vector3 lookPoint = new Vector3(0,0,0);

	void OnEnable () {
		StateMachine.SunTempleActivated += SunTempleActive;
		StateMachine.WaterTempleActivated += WaterTempleActive;
		StateMachine.TrashTempleActivated += TrashTempleActive;
	}
	
	void OnDisable () {
		StateMachine.SunTempleActivated -= SunTempleActive;
		StateMachine.WaterTempleActivated -= WaterTempleActive;
		StateMachine.TrashTempleActivated -= TrashTempleActive;
	}

    private Rigidbody _Rbody { get { return GetComponent<Rigidbody>(); } }
  
	void Start () 
	{

		DialogTrack = new string[] {
			"<color=red>You there! Please help us ! Bzz Bzz\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red> Our garden is dying, please activate the three temples\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red>Jeff will take you to the first temple, the Sun Temple Bzz Bzz\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red>Jeff is the big bee flying around \n \n </color>" + "Click any mousebutton to continue...",
			"",
            "<color=red> Thank you for activating the Sun Temple! Bzz Bzz\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red> Please to go the Water Temple now \n \n </color>" + "Click any mousebutton to continue...",
			"<color=red> It's the big blue watering can!\n \n </color>" + "Click any mousebutton to continue...",
            "",//8 -- Water Temple
			"<color=red> Thank you for activating the Water Temple!\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red>Please to go the Trash Temple now  Bzz Bzz\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red> It's the big coca cola can\n \n </color>" + "Click any mousebutton to continue...",
            "",//12 -- Everything
			"<color=red> Yaay!!\n \n </color>" + "Click any mousebutton to continue...", //13
			"<color=red> Our Garden is saved !\n \n </color>" + "Click any mousebutton to continue...",
			"<color=red> All thanks to you Bzz Bzz!\n \n </color>" + "Click any mousebutton to continue...",//15
            "",
			
		};

	}

	void SunTempleActive () {
		firstWord = 5;
        ArrowEnabled = true;
      
    }
	
	void WaterTempleActive () 
    {
		firstWord = 9;
        ArrowEnabled = true;
    }

    void TrashTempleActive()
    {
        firstWord = 13;
        ArrowEnabled = true;
    }

	void Update () 
	{
      //  Debug.Log(ArrowEnabled);
       // Debug.Log(firstWord);

        if (talkTrigger) {

            if (Input.GetKey("e"))
            {
                inDia = true;
               _Rbody.constraints = RigidbodyConstraints.FreezeAll;
               UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = false;
                this.transform.LookAt(lookPoint);
                talkTrigger = false;
            }
		}

		if (inDia & Input.GetMouseButtonDown (0) || Input.GetMouseButtonDown (1)) {

			firstWord += 1;

            if (firstWord == 4 )
            {
                ArrowEnabled = false;
                inDia = false;
                finishedTalk1 = true;
                _Rbody.constraints = RigidbodyConstraints.FreezeRotation;
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;
                firstWord = 0;
            }
            
            if (firstWord == 8)
            {
                ArrowEnabled = false;
                inDia = false;
                _Rbody.constraints = RigidbodyConstraints.FreezeRotation;
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;

                firstWord = 4;
            }
            
			if (firstWord == 12) { //If Water
                ArrowEnabled = false;
                inDia = false;
                _Rbody.constraints = RigidbodyConstraints.FreezeRotation;
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;
               
                firstWord = 9;
			}
           
            if (firstWord == 16)
            {
                ArrowEnabled = false;
                inDia = false;
                _Rbody.constraints = RigidbodyConstraints.FreezeRotation;
                UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MouseLookEnabled = true;
         
                firstWord = 13;
            }
        } 
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "KingBee")
		{
			talkTrigger = true;
			lookPoint = other.transform.position;
		
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "KingBee") {
			talkTrigger = false;
		}
	}

	void OnGUI()
	{
        GUI.skin = _guiSkin;
		if (inDia) 
			GUI.Box (new Rect (10, 10, 400, 60),DialogTrack[firstWord]);


		if(talkTrigger)
			GUI.Box(new Rect (Screen.width/2, Screen.height/2, 100,50), "Press E to Talk");
	}


}
