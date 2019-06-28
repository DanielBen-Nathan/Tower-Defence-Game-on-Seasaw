using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour ,IProjectile {
    public GameObject from;
    public float speed;
    public int dmg;
    private GameObject enemy;
    public GameObject explosion;
    public float explosionTime;
  
    private GameObject explosionObj;
    private bool readyToDestroy = false;

    private bool foundTarg = false;
    private bool explodeOnce = true;

    public int xAdd;
    public int yAdd;
    private bool completedCheck = false;
    private Vector3 lastPos;
    // Use this for initialization
    void Start () {
        AttackRanged at = from.GetComponent<AttackRanged>();

        enemy = at.GetClosestTarget();
        enemy.GetComponent<OrcScript>();
        int add = 0;
        if (enemy.transform.position.x < transform.position.x)
        {
            add = -xAdd;

        }
        else {
            add = xAdd;
        }
        lastPos = new Vector2(enemy.transform.position.x+add, enemy.transform.position.y-yAdd);
    }
	
	// Update is called once per frame
	void Update () {

        // if (enemy != null)//&&enemy.GetComponent<OrcScript>().GetDead()==false)
        // {
        // lastPos = enemy.transform.position;
        //  transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
        //}
        //else {
        //  transform.position = Vector2.MoveTowards(transform.position,lastPos, speed * Time.deltaTime);


        // }
        // GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0));

        if (transform.position != lastPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, lastPos, speed * Time.deltaTime);

        }
      

    }
    public void SetFromObj(GameObject from)
    {
        this.from = from;


    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;


    }
    public void SetDmg(int dmg)
    {
        this.dmg = dmg;

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (explodeOnce) {

            if (col.gameObject.name == "grass" )
            {
                explodeOnce = false;
                //Destroy(gameObject);
                explosionObj = Instantiate(explosion, transform.position, Quaternion.identity);
                GetComponent<SpriteRenderer>().enabled = false;
                EnemiesInRadius();

                StartCoroutine(ExplosionTime());
                
            }


        }
        


    }

    IEnumerator ExplosionTime()
    {


     
        yield return new WaitForSeconds(explosionTime);
        if (completedCheck) {
            Destroy(explosionObj);
            Destroy(gameObject);

        }
        
       



    }
    public void EnemiesInRadius() {

        Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, explosion.transform.localScale.x);
        for (int i = 0; i < inRange.Length; i++) {
            
            if ((inRange[i].tag == "enemy" && from.tag=="tower")) {
                try
                {
                    inRange[i].GetComponent<OrcScript>().TakeDamage(dmg);

                }
                catch (NullReferenceException e) {


                }
               


            }
            if ((inRange[i].tag == "tower" && from.tag == "enemy")) {
                inRange[i].GetComponent<Tower>().TakeDamage(dmg);


            }

        }

        completedCheck = true;

    }
   
}
