using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : MonoBehaviour {
    public float distanceAttack = 0.02f;
    public float distanceRay = 0.4f;
    public int dmg;
    private GameObject hitObj;
    private Walkable walkable;
    // Use this for initialization
    void Start () {
        walkable = GetComponent<Walkable>();
    }
	
	// Update is called once per frame
	void Update () {
        Attack();
	}


    public void Attack()
    {

        RaycastHit2D hit;
        Vector2 dir = new Vector2(1, 0);
        Vector2 pos = new Vector2(transform.position.x + distanceRay, transform.position.y);
        if (transform.position.x > walkable.gem.transform.position.x)
        {
            dir = new Vector2(-1, 0);
            pos = new Vector2(transform.position.x - distanceRay, transform.position.y);
        }

        hit = Physics2D.Raycast(pos, dir, distanceAttack, LayerMask.GetMask("Default"));



        if (hit.collider != null)
        {
            

            if (hit.collider.tag == "tower")
            {

                GetComponent<Animator>().SetBool("moving", false);
                walkable.walking = false;


                GetComponent<Animator>().SetBool("attack", true);
                hitObj = hit.collider.gameObject;

            }


        }
        else
        {

            GetComponent<Animator>().SetBool("moving", true);
            GetComponent<Animator>().SetBool("attack", false);
            walkable.walking = true;

        }

    }
    public GameObject GetHitObj()
    {
        return hitObj;


    }

}
