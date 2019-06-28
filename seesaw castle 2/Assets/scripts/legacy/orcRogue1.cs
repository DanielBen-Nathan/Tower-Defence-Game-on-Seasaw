using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orcRogue1 : OrcScript
{

    private Walkable walkable;
    private AttackMelee attack;
    

    // Use this for initialization
    void Start()
    {
        walkable = GetComponent<Walkable>();
        attack = GetComponent<AttackMelee>();
        Start2();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Update2();
      //  walkable.Walk();
        attack.Attack();



    }



    //private void OnCollisionEnter2D(Collision2D col)
    ///{

       // if (col.collider.tag == "enemy")
      //  {
         //   walkable.walking = false;
         //   GetComponent<Animator>().SetBool("moving", false);


       // }
       // ParentColliders(col);




    //}
   
}