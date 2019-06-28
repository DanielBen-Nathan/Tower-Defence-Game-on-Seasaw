using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        GetComponent<Camera>().orthographicSize = 1920 / currentAspect / 110;
    }
	
	// Update is called once per frame
	void Update () {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        GetComponent<Camera>().orthographicSize = 1920 / currentAspect / 110;
    }
}
