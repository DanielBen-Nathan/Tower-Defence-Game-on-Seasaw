using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnemy : MonoBehaviour {

    public AttackRanged ar;
    public float speed=10;
    private GameObject enemy;
    //public float incSpeed = 2;
    // Use this for initialization
    void Start()
    {
        //at= GetComponentInParent<ArcherTower>();
        //at.GetClosestEnemy()
        enemy = ar.GetClosestTarget();
        //speed = oa.GetDmg() + incSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null )//&& enemy.GetComponent<Tower>().GetDead() == false)
        {
            
            
            //transform.Rotate(Vector2.right * 50f * Time.deltaTime);
            Vector3 vectorToTarget = enemy.transform.GetChild(1).position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);


            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.GetChild(1).position, speed * Time.deltaTime);
            //if (enemy.transform.position.x < transform.position.x) {
            // transform.localRotation = Quaternion.Euler(0, 180, 0);

            //}
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
