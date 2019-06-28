using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInterface : MonoBehaviour {
    public GameObject settings;
    public GameObject help;
    public GameObject buttons;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnPlay() {
        SceneManager.LoadScene("scene1");


    }
    public void OnQuit()
    {
        Application.Quit();


    }
    public void OnSettings()
    {
        settings.SetActive(true);
        buttons.SetActive(false);


    }
    public void OnBackSettings()
    {
        help.SetActive(false);
        settings.SetActive(false);
        buttons.SetActive(true);


    }
    public void OnHelp()
    {
        help.SetActive(true);
        buttons.SetActive(false);


    }

}
