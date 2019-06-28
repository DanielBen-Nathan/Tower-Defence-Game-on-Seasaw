using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {
    public float jumpProb;//between 0 and 1
    public float jumpTimer;//time between jump checks
    private bool readyJump = true;
    // Use this for initialization
    private Walkable walkable;
    void Start () {
        walkable = GetComponent<Walkable>();
	}
	
	// Update is called once per frame
	void Update () {
        if (readyJump)
        {
            float jumpChance = Random.Range(0, jumpProb);
            if (jumpChance <= jumpProb)
            {
                if (walkable.right)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 100));

                }
                else {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 100));
                }
              
                StartCoroutine(WaitBetweenJumps());

            }
        }
    }
    IEnumerator WaitBetweenJumps()
    {
        readyJump = false;
        yield return new WaitForSeconds(jumpTimer);
        readyJump = true;
    }
}
