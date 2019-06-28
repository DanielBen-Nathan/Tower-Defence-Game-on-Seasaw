using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSnap : MonoBehaviour {
    private float timer;
    private float wait;
    public float snapDistance;
    //public float snapDistance2;
    public float snapDistancePhone;
    private bool once = true;
	// Use this for initialization
	void Start () {
        if (Application.platform == RuntimePlatform.Android) {
            snapDistance = snapDistancePhone;

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (once) {
            once = false;
            if (col.gameObject.name == gameObject.name || col.gameObject.name =="gem")
            {
                Debug.Log(col.gameObject.transform.position.y);
                Debug.Log(transform.position.y);
                if (col.gameObject.transform.position.y < transform.position.y ||(col.gameObject.name == "gem" && col.gameObject.transform.position.y-4 < transform.position.y))
                {
                    Debug.Log("above");
                    if (col.gameObject.transform.position.x < transform.position.x + snapDistance && col.gameObject.transform.position.x > transform.position.x - snapDistance)
                    {
                        Debug.Log("close");
                        transform.position = new Vector2(col.gameObject.transform.position.x, transform.position.y);
                        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                    //else if (col.gameObject.transform.position.x < transform.position.x + snapDistance2 && col.gameObject.transform.position.x > transform.position.x - snapDistance2)
                   // {
                       // if (col.gameObject.transform.position.x < transform.position.x) {
                         //   transform.position = new Vector2(col.gameObject.transform.position.x+snapDistance, transform.position.y);

                       // }
                       // if (col.gameObject.transform.position.x > transform.position.x)
                       // {
                            //transform.position = new Vector2(col.gameObject.transform.position.x - snapDistance, transform.position.y+0.5f);

                       // }

                    //}
                }

            }



        }
        
    }
}
