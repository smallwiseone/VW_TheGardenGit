using UnityEngine;
using System.Collections;

public class CodeMenu : MonoBehaviour {

    Texture2D StartButton;
    Texture2D ExitButton;

    void Start() 
    { 
         
    }

    void OnGUI() 
    {
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 3, 100, 50), "Start Game")) 
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Exit Game"))
        {
            Application.Quit();
        }
        
    }
}
