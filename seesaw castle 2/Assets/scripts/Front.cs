using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("enter");
        if (collision.gameObject.tag == "tower" || collision.gameObject.tag == "enemy")
        {
          
            GetComponentInParent<Walkable>().walking = false;
            

        }
       

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       // Debug.Log("exit");
        if (collision.gameObject.tag == "tower" || collision.gameObject.tag == "enemy")
        {
           
            GetComponentInParent<Walkable>().walking = true;


        }
    }
  
}

