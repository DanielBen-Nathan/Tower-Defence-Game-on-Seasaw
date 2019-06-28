using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour {
    public GameObject grass;
    public int height;
    private GameObject grassObj;
    public int grassSpawnHeight=11;
    // Use this for initialization
    void Start () {
        grassObj = GameObject.Find("grass");

	}
	
	// Update is called once per frame
	void Update () {
        if (grassObj.transform.position.y < -height) {
            float mass = grassObj.GetComponent<Rigidbody2D>().mass;
            Destroy(grassObj);
            grassObj = Instantiate(grass, new Vector2(0, grassSpawnHeight), transform.rotation);
            grassObj.GetComponent<Rigidbody2D>().mass = mass;
        }
	}
}
