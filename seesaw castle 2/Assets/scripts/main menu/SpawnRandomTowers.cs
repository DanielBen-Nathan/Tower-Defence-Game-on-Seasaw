using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTowers : MonoBehaviour {
    public GameObject[] towers;
    public float radius;
    public float waitTime;
    public float height;
    private bool ready=true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ready) {
            GameObject archerTowerObj = Instantiate(towers[0], new Vector2(Random.Range(-radius, radius), height), transform.rotation);
            StartCoroutine(WaitBetweenSpawns());
        }
       
    }

    IEnumerator WaitBetweenSpawns()
    {

        ready = false;

        yield return new WaitForSeconds(waitTime);

        ready = true;



    }
}
