using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRanged : MonoBehaviour {
    public GameObject projectile;
    public float range;
    public float attackSpeed;
    public bool ready = true;
    public int dmg;
    public float speed;
    public string targetTag;
    public string fromTag;
    private GameObject closestTarget = null;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frames
	void Update () {
        if (gameObject.tag == "enemy") {
            Attack();
        }
       

	}


    public void Attack()
    {
        if (ready == true)
        {
            float closest = FindClosestTarget();
            if (closest != float.MaxValue)//&& closestEnemy.transform.position.y<=transform.position.y
            {

                GameObject projectileObj = Instantiate(projectile, transform.position, transform.rotation);
                IProjectile proj = projectileObj.GetComponent<IProjectile>();
                proj.SetFromObj(gameObject); //= GetComponent<AttackRanged>();
                proj.SetSpeed(speed);
                proj.SetDmg(dmg);
                projectileObj.tag = fromTag;
                //closestEnemy.GetComponent<Tower>().TakeDamage(dmg);
                StartCoroutine(WaitBetweenAttacks());
            }
        }

    }
    IEnumerator WaitBetweenAttacks()
    {

        ready = false;

        yield return new WaitForSeconds(attackSpeed);


        ready = true;


    }
    public GameObject GetClosestTarget()
    {
        return closestTarget;


    }
    public float FindClosestTarget() {

        Collider2D[] inRange = Physics2D.OverlapCircleAll(transform.position, range);

        float closest = float.MaxValue;
        closestTarget = null;
        for (int i = 0; i < inRange.Length; i++)
        {


            if (inRange[i].gameObject.tag == targetTag)
            {
                //enemies[i] = inRange[i].gameObject;
                Vector2 v = new Vector2(transform.position.x, transform.position.y);
                float testClose = Vector2.Distance(transform.position, inRange[i].gameObject.transform.position);
                if (closest > testClose)
                {
                    closest = testClose;
                    closestTarget = inRange[i].gameObject;
                    if (closestTarget.tag == "tower") {
                        closestTarget=closestTarget.transform.GetChild(1).gameObject;

                    }




                }

            }
        }

        return closest;

    }
}
