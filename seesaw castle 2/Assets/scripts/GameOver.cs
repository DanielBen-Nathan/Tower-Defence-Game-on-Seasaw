using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public GameObject grass;
  
    public float fallHeight=3.5f;

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (grass.transform.position.y < -fallHeight) {
          
            GetComponent<UserInterface>().OnGameOver();

        }
	}
}
