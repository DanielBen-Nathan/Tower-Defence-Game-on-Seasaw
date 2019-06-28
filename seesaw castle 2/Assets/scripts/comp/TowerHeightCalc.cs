using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeightCalc : MonoBehaviour {
    public float dmgProp = 0.5f;
    public float rngProp = 1.03f;
    public float dmgAdd ;
    public float rngAdd ;
    private AttackRanged attack;
    private int dmg;
    private float range;
    // Use this for initialization
    void Start () {
        attack = GetComponent<AttackRanged>();
    }
	
	// Update is called once per frame
	void Update () {
        //range = Mathf.Pow(transform.position.y, rngProp) + rngAdd;
        range = Mathf.Abs((int)(transform.position.y * rngProp + rngAdd));
        dmg = Mathf.Abs((int)(transform.position.y * dmgProp + dmgAdd));
        attack.dmg = dmg;
        attack.range = range;
        attack.speed = dmg;
        attack.Attack();
    }
}
