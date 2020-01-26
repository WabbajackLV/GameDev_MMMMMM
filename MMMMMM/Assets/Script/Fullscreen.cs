using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FullScreen : MonoBehaviour
{
    void Start()
    {
        // Toggle fullscreen
        Screen.fullScreen = !Screen.fullScreen;
		Screen.SetResolution(1920, 1080, true);
    }
	
 	void OnApplicationQuit () 
	{
		PlayerPrefs.SetInt("Screenmanager Resolution Width", 1920);
		PlayerPrefs.SetInt("Screenmanager Resolution Height", 1080);
		PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 1);
	}
}