using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcArcher1 : OrcScript {

    private Walkable walkable;
    private AttackRanged attack;

    // Use this for initialization
    void Start () {
        walkable = GetComponent<Walkable>();
        attack = GetComponent<AttackRanged>();
        Start2();
	}
	
	// Update is called once per frame
	void Update () {
        Update2();

        //walkable.Walk();

        attack.Attack();



        }

    //private void OnCollisionEnter2D(Collision2D col)
    //{

        //if (col.collider.tag == "enemy")
       // {
            //walking = false;
            //GetComponent<Animator>().SetBool("moving", false);


      //  }
        //else {
           // walking = true;
            //GetComponent<Animator>().SetBool("moving", true);


       // }
       // ParentColliders(col);




    //}

    public AttackRanged getAttack() {
        return attack;


    }
    
    
    

}
