using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitGame : MonoBehaviour {

	// Use this for initialization
	public void DoExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
