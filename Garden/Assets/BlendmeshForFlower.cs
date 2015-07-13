using UnityEngine;
using System.Collections;

public class BlendmeshForFlower : MonoBehaviour {

	//int blendShapeCount;
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh skinnedMesh;
	float blendOne = 0f;
	float blendTwo = 0f;
	float blendSpeed = 0.1f;
	bool blendOneFinished = false;


	void Awake ()
	{
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;
	}


	void Start () {
		//blendShapeCount = skinnedMesh.blendShapeCount; 
	}
	
	// Update is called once per frame
	void Update () {
	
		skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);
		blendOne += blendSpeed;


	if (blendOne > 100)
		{
			blendSpeed = -Random.Range (0.1f, 0.6f);;
		}

		if (blendOne < 0) {

			blendSpeed = 1f;
		}

	}
}
