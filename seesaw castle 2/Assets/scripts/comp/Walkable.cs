using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour {
    public bool walking = true;
    public float distance = 0.5f;
    public bool right;
    public GameObject gem;
    
    // Use this for initialization
    void Start () {
        gem = GameObject.Find("gem");
    }
	
	// Update is called once per frame
	void Update () {
        Walk();
	}
    public void Walk()
    {
        if (walking)
        {

          

           
            if (transform.position.x > gem.transform.position.x)
            {
             
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                transform.position = new Vector2(transform.position.x - distance * Time.deltaTime, transform.position.y);
                right = false;
            }
            if (transform.position.x <= gem.transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                transform.position = new Vector2(transform.position.x + distance * Time.deltaTime, transform.position.y);
                right = true;
            }
            GetComponent<Animator>().SetBool("moving", true);
        }
        else
        {

            GetComponent<Animator>().SetBool("moving", false);
        }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {

       // if (col.collider.tag == "enemy")
        //{
           // walking = false;
           // GetComponent<Animator>().SetBool("moving", false);


       // }
        //ParentColliders(col);




    }
    private void OnCollisionExit2D(Collision2D col)
    {

        //if (col.collider.tag == "enemy")
       // {
           // walking = true;
           // GetComponent<Animator>().SetBool("moving", true);


      //  }
        //ParentColliders(col);




    }
}

