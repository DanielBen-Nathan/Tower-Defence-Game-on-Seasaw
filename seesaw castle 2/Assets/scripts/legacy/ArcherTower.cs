using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower {
    //public float attackSpeed = 1;
    public float dmgProp = 0.5f;
    public float rngProp = 1.03f;


    private int dmg;
    private float range;
   
    private GameObject closestEnemy = null;
    private bool ready = true;
    private AttackRanged attack;

    //private GameObject[] enemies;

    // Use this for initialization
    void Start() {
        attack = GetComponent<AttackRanged>();
        Start2();
    }

    // Update is called once per frame
    void Update()
    {
        Update2();

        range = Mathf.Pow(transform.position.y, rngProp) + 3;
        dmg = Mathf.Abs((int)(transform.position.y * dmgProp + 3));
        attack.dmg = dmg;
        attack.range = range;
        attack.speed = dmg + 2;
        attack.Attack();
    }
        //Debug.Log(range);

        //if (ready == true)
        //{
        //    Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, range);

        //    float closest = float.MaxValue;
        //    //GameObject closestEnemy = null;
        //    for (int i = 0; i < inRange.Length; i++)
        //    {
        //        if (inRange[i].gameObject.tag == "enemy")
        //        {
        //            //enemies[i] = inRange[i].gameObject;
        //            Vector2 v = new Vector2(transform.position.x, transform.position.y);
        //            float testClose = Vector2.Distance(transform.position, inRange[i].gameObject.transform.position);
        //            if (closest > testClose)
        //            {
        //                closest = testClose;
        //                closestEnemy = inRange[i].gameObject;




        //            }

        //        }


        //    }
        //    if (closest != float.MaxValue)//&& closestEnemy.transform.position.y<=transform.position.y
        //    {
        //        GameObject arrowObj = Instantiate(arrow, transform.position, transform.rotation);
        //        arrowObj.GetComponent<Arrow>().at = GetComponent<ArcherTower>();
               
        //        StartCoroutine(WaitBetweenAttacks());
        //    }
        //}




    //}
    //IEnumerator WaitBetweenAttacks()
    //{

    //    ready = false;

    //    yield return new WaitForSeconds(attackSpeed);


    //    ready = true;


    //}

    //public GameObject GetClosestEnemy() {
    //    return closestEnemy;


    //}
    //public int GetDmg() {
    //    return dmg;

    //}


}
