using UnityEngine;
using System.Collections;

public class OnLoadClick : MonoBehaviour {

	public void LoadScene(int level)
	{

		Application.LoadLevel(level);
	}
}
