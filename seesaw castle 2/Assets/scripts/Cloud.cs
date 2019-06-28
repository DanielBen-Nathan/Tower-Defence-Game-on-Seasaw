using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public int stopPos = 35;
    public float distance = 1.5f;
   

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x +distance * Time.deltaTime, transform.position.y);
        if (transform.position.x > stopPos) {
            Destroy(this.gameObject);
        }
    }

   
      


    
}
