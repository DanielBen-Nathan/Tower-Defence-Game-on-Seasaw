using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour {
    public Canvas menu;
    public Button menuButton;
    public Canvas gameover;
    public Text scoreOverText;
    public Canvas[] canvasesToDisable;
    public GameObject towerSelector;

    public GameObject settings;
    public GameObject help;
    public GameObject buttons;

    public bool paused = false;
    private bool menuButtonPressed = false;
    public bool over = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || menuButtonPressed)
        {
            if (!paused)
            {
                Time.timeScale = 0;
                ShowMenu();

                menuButton.GetComponentInChildren<Text>().text = "Back";

            }
            else
            {
                Time.timeScale = 1;
                HideMenu();
                menuButton.GetComponentInChildren<Text>().text = "Menu";
            }

            paused = !paused;
        }
        menuButtonPressed = false;
    }


    public void ShowMenu() {

        menu.enabled = true;
        towerSelector.SetActive(false);

    }
    public void HideMenu()
    {
        towerSelector.SetActive(true);
        menu.enabled = false;

    }

    public void OnMenuButton() {
        menuButtonPressed = true;

    }

    public void OnGameOver() {
        if (!over) {
            for (int i = 0; i < canvasesToDisable.Length; i++)
            {
                canvasesToDisable[i].enabled = false;

            }

            scoreOverText.text = "Score: " + GetComponent<Score>().GetScore();
            gameover.enabled = true;
            over = true;
            ShowMenu();


        }
       


    }

    public void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main menu");


    }
    public void OnRetry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("scene1");


    }
    public void OnHelp()
    {
        help.SetActive(true);
        buttons.SetActive(false);
        


    }
    public void OnBack() {

        help.SetActive(false);
        settings.SetActive(false);
        buttons.SetActive(true);

    }
    public void OnSettings()
    {
        settings.SetActive(true);
        buttons.SetActive(false);


    }
}
