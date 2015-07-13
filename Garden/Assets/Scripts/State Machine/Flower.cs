using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour {

	private int randomFrame;
	private bool blendOneFinished = false;
	private int blendShapeCount;
	private SkinnedMeshRenderer skinnedMeshRenderer;
	private Mesh skinnedMesh;
	private Random random;
	private int blendOne = 0;
	private int blendTwo = 0;
	private int blendSpeed = 1;
	public bool TempleIsActivated = false;
	public static int State = 0;
	
	void Awake ()
	{
		random = new Random ();
		randomFrame = Random.Range (0, 100);
		blendOne = randomFrame;
		blendTwo = randomFrame;
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
	}

	void Start () {
		blendShapeCount = skinnedMesh.blendShapeCount; 
	}

	void OnEnable () {
		StateMachine.SunTempleActivated += SunTempleActive;
		StateMachine.WaterTempleActivated += WaterTempleActive;
	}

	void OnDisable () {
		StateMachine.SunTempleActivated -= SunTempleActive;
		StateMachine.WaterTempleActivated -= WaterTempleActive;
	}

	void SunTempleActive () {
		Debug.Log ("Sun Temple Active");
		State=2;
	}

	void WaterTempleActive () {
		Debug.Log ("Water Temple Active");
		State = 1;
	}

	void Update () {
		//Code before any temple is activated
		skinnedMeshRenderer.SetBlendShapeWeight (State, blendOne);
		blendOne += blendSpeed;

		if (blendOne > 100)
		{
			blendSpeed = -1;
		}
		
		if (blendOne < 0) {
			
			blendSpeed = 1;
		}

		//Execute code for when temple is activated
		if (TempleIsActivated == true) {
			//Insert magic to be executed at every frame.
			State=2;
		}
	}
}