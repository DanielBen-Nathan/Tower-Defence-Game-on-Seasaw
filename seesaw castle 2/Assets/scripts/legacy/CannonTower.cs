using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower {
    private AttackRanged attack;
    // Use this for initialization
    public float dmgProp;
    public float rngProp;
    private int dmg;
    private float range;
    void Start () {
        attack = GetComponent<AttackRanged>();
        Start2();
    }
	
	// Update is called once per frame
	void Update () {
        Update2();
        //float distanceBetween2 =attack.FindClosestTarget();
        //GameObject enemy=  attack.GetClosestTarget();
        //float distanceBetween =    transform.position.x - enemy.transform.position.x;
        //attack.speed = distanceBetween2/2;

        range = Mathf.Pow(transform.position.y, rngProp) + 3;
        dmg = Mathf.Abs((int)(transform.position.y * dmgProp + 5));
        attack.dmg = dmg;
        attack.range = range;
        attack.speed = dmg + 2;
        attack.Attack();//if ground
	}
}
