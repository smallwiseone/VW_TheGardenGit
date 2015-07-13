using UnityEngine;
using System.Collections;

public class BlendmeshBee : MonoBehaviour {

//	int blendShapeCount;
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	float blendOne = 0f;
	float blendTwo = 0f;
	public float blendSpeed = 15f;
	bool blendOneFinished = false;


	void Awake ()
	{
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
	}


	void Start () {
	//	blendShapeCount = skinnedMesh.blendShapeCount; 
	}
	
	// Update is called once per frame
	void Update () {
	
		skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);
		blendOne += blendSpeed;


	if (blendOne > 100)
		{
			blendSpeed = -15f;
		}

		if (blendOne < 0) {

			blendSpeed = 15f;
		}


/*
		if (blendShapeCount > 2) {
			
			if (blendOne < 100f) {
				skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);
				blendOne += blendSpeed;
			} else {
				blendOneFinished = true;
			}
			
			if (blendOneFinished == true && blendTwo < 100f) {
				skinnedMeshRenderer.SetBlendShapeWeight (1, blendTwo);
				blendTwo += blendSpeed;
			}
			
		}

*/

	}
}
