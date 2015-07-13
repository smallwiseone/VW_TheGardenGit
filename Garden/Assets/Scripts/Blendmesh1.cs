using UnityEngine;
using System.Collections;

public class Blendmesh1 : MonoBehaviour {

	int blendShapeCount;
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	float blendOne = 0f;
	float blendTwo = 0f;
	float blendSpeed = 1f;
	bool blendOneFinished = false;


	void Awake ()
	{
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
	}


	void Start () {
		blendShapeCount = skinnedMesh.blendShapeCount; 
	}
	
	// Update is called once per frame
	void Update () {
	
		skinnedMeshRenderer.SetBlendShapeWeight (2, blendTwo);
		blendTwo += blendSpeed;


	if (blendTwo > 100)
		{
			blendSpeed = -1f;
		}

		if (blendTwo < 0) {

			blendSpeed = 1f;
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
