using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallSeeker : MonoBehaviour, IProjectile
{

    public GameObject from;
    //public ArcherTower at;
    public float speed = 10;
    public int dmg;
    private GameObject enemy;

    //public float incSpeed = 2;
    // Use this for initialization
    void Start()
    {
        //at= GetComponentInParent<ArcherTower>();
        //at.GetClosestEnemy()
        AttackRanged at = from.GetComponent<AttackRanged>();

        enemy = at.GetClosestTarget();
        //speed = at.dmg + incSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)//&&enemy.GetComponent<OrcScript>().GetDead()==false)
        {
            //Debug.Log(at.GetDmg());
            //transform.Rotate(Vector2.right * 50f * Time.deltaTime);
            Vector3 vectorToTarget = enemy.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);


            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, speed * Time.deltaTime);
            //if (enemy.transform.position.x < transform.position.x) {
            // transform.localRotation = Quaternion.Euler(0, 180, 0);

            //}
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // public int GetDmg() {
    //return at.GetDmg();

    // }
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

}
