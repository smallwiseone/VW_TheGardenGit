using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public Terrain before;
	public Terrain after;

	public GameObject _trash;
	public GameObject _garden;

	public Material sky1;
	public Material sky2;

	bool waterActive = false;
	bool sunActive = false;
	bool trashActive = false;


	void Start()
	{
		RenderSettings.skybox = sky1;
	}

	void Update()
	{
		//TODO add more objects to be activated after finishing mini-games.

		if (waterActive && sunActive && trashActive) 
		{
			//terrains
			before.gameObject.SetActive(false);
			after.gameObject.SetActive(true);

			//trash
			_trash.SetActive(false);
			//garden
			_garden.SetActive(true);

			RenderSettings.skybox = sky2;
		}
	}

	void OnEnable () {
		StateMachine.WaterTempleActivated += WaterTempleActive;
		StateMachine.SunTempleActivated += SunTempleActive;
		StateMachine.TrashTempleActivated += TrashTempleActive;
	}
	
	
	void OnDisable() {
		//StateMachine.WaterTempleActivated -= WaterTempleActive;
	}

	void WaterTempleActive () 
	{
		waterActive = true;
		Debug.Log("Water Activated");
	}
	void SunTempleActive () 
	{
		sunActive = true;
		Debug.Log("Sun Activated");
	}
	void TrashTempleActive () 
	{
		trashActive = true;
		_trash.SetActive(false);
		Debug.Log("Trash Activated");
	}
}
