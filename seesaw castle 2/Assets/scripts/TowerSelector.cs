using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerSelector : MonoBehaviour {

    public Button[] buttons;
    public GameObject[] towers;

    public GameObject selectedTower;

	// Use this for initialization
	void Start () {
        //Color cb = archerTowerButton.GetComponent<Image>().color;
        //cb.a = 0.5f;
        //archerTowerButton.GetComponent<Image>().color = cb;

        SelectTower(selectedTower);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectTower(GameObject tower) {
        for (int i = 0; i < towers.Length; i++) {
            if (tower.ToString() == towers[i].ToString())
            {
                Color cb = buttons[i].GetComponent<Image>().color;
                cb.a = 1;
                buttons[i].GetComponent<Image>().color = cb;
                selectedTower = tower;

            }
            else {
                Color cb = buttons[i].GetComponent<Image>().color;
                cb.a = 0.5f;
                buttons[i].GetComponent<Image>().color = cb;

            }


        }


    }

   


    public GameObject GetTower() {
        return selectedTower;


    }
   
}
