using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : AbstractMob {
   
    private GameObject[] enemies;
    private int destroyOnY = -10;
    public int fallingDmg=100;
    public int fallOffForce= 5;
    public int cost = 10;
    private Slider healthBar;


    // Use this for initialization
    void Start () {
        Start2();
        
      
    }
    public void Start2() {
        health = maxHealth;
        healthBar = GetComponentInChildren<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0, -1f);
    }
	
	// Update is called once per frame
	void Update () {
        //enemies = GameObject.FindGameObjectsWithTag("enemy");
        Update2();

    }
    public void Update2() {
        if (transform.position.y < destroyOnY)
        {
            TakeDamage(maxHealth);



        }


    }
   

    public void TakeDamage(int dmg) {
        health = health - dmg;
        healthBar.value = health;
        if (health <= 0) {
            SpawnTowers st = GameObject.Find("beam 1").GetComponent<SpawnTowers>();
            if (st == null)
            {
                Destroy(this.gameObject);
            }
            else {
                st.RemoveTower(this.gameObject);
            }
           
          


        }



    }


   // IEnumerator RegenHealth()
   // {

      //  ready = false;
      
       // yield return new WaitForSeconds(regenTime);
      //  TakeDamage(-healthRegen);

       // ready = true;


   // }


    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("tower col");
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);

        if (col.collider.tag == "head" && GetComponent<Rigidbody2D>().velocity.magnitude>0.01)
        {

          
            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fallOffForce));
            OrcScript os = col.collider.gameObject.GetComponentInParent<OrcScript>();
           // Debug.Log("fal dmg");
            os.TakeDamage(fallingDmg);


        }
        




    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "projectileOrc")//&&gameObject!=null&& col.gameObject!=null)
        {
            
            TakeDamage(col.gameObject.GetComponent<Arrow>().dmg);
            Destroy(col.gameObject);
        }
    }





}
