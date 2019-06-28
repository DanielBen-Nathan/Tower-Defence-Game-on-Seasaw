using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHeightSpawner : MonoBehaviour {
    public GameObject cloud;
    public float waitTime1 = 0.5f;
    public float waitTime2 = 6;
    public int cloudeSpawnX = -30;
    public int cloudSpawnY = 5;
    public int cloudSpawnMaxY;
    //public float firstLimit;


    private SpawnTowers spawnTowers;
    private System.Random ran = new System.Random();
    private bool ready = true;
    private Score scoreScript;

    // Use this for initialization
    void Start () {
        spawnTowers = GameObject.Find("beam 1").GetComponent<SpawnTowers>();
        //scoreScript = GameObject.Find("beam 1").GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ready == true) {
            SpawnCloud();

        }


		
	}


    public void SpawnCloud() {
        int y = 0;
        if (spawnTowers != null)
        {
            y = ran.Next(cloudSpawnY, (int)spawnTowers.highest);
        }
        else {
            Debug.Log("null");
            y = ran.Next(cloudSpawnY, cloudSpawnMaxY);
        }
       

        GameObject cloudObj = Instantiate(cloud, new Vector2(cloudeSpawnX, y), transform.rotation);
        StartCoroutine(WaitBetweenSpawns());

    }

    IEnumerator WaitBetweenSpawns()
    {


        ready = false;
        yield return new WaitForSeconds(Random.Range(waitTime1, waitTime2));
        ready = true;
      



    }
}
