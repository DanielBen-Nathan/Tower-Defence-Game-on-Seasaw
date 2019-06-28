using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrcScript : AbstractMob
{
   
   
   
   
    public int scoreWorth;
    public int goldWorth;
    private GameObject gem;

    //protected GameObject hitObj;
    private bool once = true;
    private bool dead = false;
    private int destroyOnY = -10;
    private Score scoreScript;
    private Slider healthBar;

    // Use this for initialization
    void Start()
    {
        Start2();
    }

    public void Start2() {
        gem = GameObject.Find("gem");
        health = maxHealth;
        scoreScript = GameObject.Find("beam 1").GetComponent<Score>();

        healthBar = GetComponentInChildren<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        Update2();



    }
    public void Update2() {
        if (transform.position.y < destroyOnY)
        {
            TakeDamage(maxHealth);



        }
    }

    

    
    private void OnTriggerEnter2D(Collider2D col)
    {
      
        if (col.gameObject.tag == "projectile"){//&&this.gameObject!=null) {

           // Debug.Log(col.gameObject.GetComponent<Arrow>().dmg);
            TakeDamage(col.gameObject.GetComponent<Arrow>().dmg);
            Destroy(col.gameObject);
        }
    }


    public void TakeDamage(int dmg)
    {
        if (dead == false)
        {
           
            health = health - dmg;
            healthBar.value = health;
            if (health <= 0)
            {
                scoreScript.AddScore(scoreWorth);
                scoreScript.AddGold(goldWorth);
                dead = true;
                //Destroy(this.gameObject);
                GetComponent<Animator>().SetBool("dead", true);



            }
        }



    }

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.gameObject.tag == "portal")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(col.collider, GetComponentInChildren<BoxCollider2D>());
        }

        if (col.collider.gameObject.tag == "gem" && dead == false)
        {
            gem.GetComponent<Gem>().EnterGem();
            Destroy(this.gameObject);
           
            //Physics2D.IgnoreCollision(col.collider, GetComponent<BoxCollider2D>(),true);
            //Physics2D.IgnoreCollision(col.collider, GetComponentInChildren<BoxCollider2D>(),true);

        }
      


    }
    public bool GetDead() {
        return dead;

    }
    
}