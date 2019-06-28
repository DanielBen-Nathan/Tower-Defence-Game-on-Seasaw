using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    
    //private float[] probs;
    private bool ready = true;
    public float mul = 0.99f;
    public float time = 5;


    public int[] probs;
    private int[] readys;//0 dont spawn, 1 wait till spawn, 2 ready to spawn
   // private GameObject[] spawnableEnemies;
    // Use this for initialization
    void Start()
    {
        probs = new int[enemies.Length];

        readys = new int[enemies.Length];
        for (int i = 0; i < enemies.Length; i++) {
            readys[i] = 0;
            probs[i] = enemies[i].GetComponent<SpawnInfo>().spawnProb;
            Debug.Log(probs[i]);

        }
        for (int i = 0; i < enemies.Length; i++) {

            StartCoroutine(WaitToSpawnNext(i,enemies[i].GetComponent<SpawnInfo>().startSpawnTime));
           


            

        }

    }

    // Update is called once per frame
    void Update()
    {
       
        if (ready == true)

         {
            GameObject[] spawnableEnemies = new GameObject[enemies.Length];
            int index = 0;
            for (int i = 0; i < enemies.Length; i++)
            {
                //Debug.Log("ready "+readys[i]);
                if (readys[i] == 2) {
                    spawnableEnemies[index] = enemies[i];
                    index++;

                }

            }
            //Debug.Log(spawnableEnemies[0]);
            int totalProb = 0;
            for (int i = 0; i < spawnableEnemies.Length; i++) {
                if (spawnableEnemies[i] != null) {
                    //Debug.Log("enemy prob " + spawnableEnemies[i].GetComponent<SpawnInfo>().spawnProb);
                    //totalProb += spawnableEnemies[i].GetComponent<SpawnInfo>().spawnProb;
                    totalProb += probs[i];
                    //Debug.Log("total prob "+totalProb);
                }


            }
            int enemyType=-1;
            int randomProb = Random.Range(0, totalProb);
            //Debug.Log("rand "+randomProb);
            int inc = 0;
            SpawnInfo si = null;
            //Debug.Log(spawnableEnemies[0].name);
            for (int i = 0; i < spawnableEnemies.Length; i++)
            {
                if (spawnableEnemies[i] != null)
                {

                    //si = spawnableEnemies[i].GetComponent<SpawnInfo>();
                    // Debug.Log("upper "+si.spawnProb + inc);
                    //if (randomProb < si.spawnProb+inc && randomProb>=inc) {
                    if (randomProb < probs[i] + inc && randomProb >= inc)
                    {
                        enemyType = i;
                        break;
                        

                    }
                    //inc += si.spawnProb;
                    inc += probs[i];
                    //si.spawnProb = (int)(si.spawnProb *si.deltaSpawnProb);

                }
            }
            //int enemyType = Random.Range(0, enemies.Length);
            //Debug.Log("type "+enemyType);
            if (enemyType != -1) {
                GameObject orcObj = Instantiate(enemies[enemyType], transform.position, transform.rotation);
                SpawnInfo si2 = orcObj.GetComponent<SpawnInfo>();
               // SpawnInfo si2 = enemies[enemyType].GetComponent<SpawnInfo>();
                //si2.spawnProb = (int)(si2.spawnProb * si2.deltaSpawnProb);
                probs[enemyType]= (int)(probs[enemyType] * si2.deltaSpawnProb);

            }
            
            StartCoroutine(WaitBetweenSpawns());
         }
        //for (int i = 0; i < readys.Length; i++) {
            //if (readys[i] == 2) {
               // GameObject orcObj = Instantiate(enemies[i], transform.position, transform.rotation);
               // StartCoroutine(WaitBetweenSpawns(i));

            //}


       // }







    }


    IEnumerator WaitBetweenSpawns()
    {
       
        ready = false;
         if (time > 3)
        {
          time = time * mul;

         }

         yield return new WaitForSeconds(time);

         ready = true;
        //Debug.Log("hello?");
        //  readys[index] = 1;
        // SpawnInfo si= enemies[index].GetComponent<SpawnInfo>();
        //yield return new WaitForSeconds(si.spawnRate);
        //si.spawnRate = si.spawnRate * si.incSpawnRate;
        // readys[index] = 2;

    }

    IEnumerator WaitToSpawnNext(int index,float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        readys[index] = 2;
    }
}