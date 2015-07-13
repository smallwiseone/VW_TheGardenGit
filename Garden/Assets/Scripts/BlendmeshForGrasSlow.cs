using UnityEngine;
using System.Collections;

public class BlendmeshForGrasSlow : MonoBehaviour {

	//int blendShapeCount;
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
		//blendShapeCount = skinnedMesh.blendShapeCount; 
	}
	
	// Update is called once per frame
	void Update () {
	
		skinnedMeshRenderer.SetBlendShapeWeight (0, blendOne);
		blendOne += blendSpeed;


	if (blendOne > 100)
		{
			blendSpeed = -Random.Range (0.2f, 0.5f);
		}

		if (blendOne < 0) {

			blendSpeed = Random.Range (0.2f, 0.5f);;
		}

	}
}
