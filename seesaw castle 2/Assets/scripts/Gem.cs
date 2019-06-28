using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    private bool shake = false;
    public float amount = 0.3f;
    public float speed = 60;
    public float shakeTime = 1;

    public float amountInc = 0.1f;
    public float speedInc = 10;
    public float shakeTimeInc = 0.1f;


    public GameObject plat;

    private Score score;
    // Use this for initialization
    void Start () {
        score = GameObject.Find("beam 1").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (shake == true) {
            //transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * speed) * amount+gemUp);
            plat.transform.position = new Vector2(plat.transform.position.x, plat.transform.position.y+Mathf.Sin(Time.time * speed) * amount-amount/100);
            StartCoroutine(ShakeTime());
            



        }


	}

    public void EnterGem() {

        shake = true;
        amount += amountInc;
        speed += speedInc;
        shakeTime += shakeTimeInc;
        int scoreNum = score.GetScore();
        score.AddScore((int)((-scoreNum*0.05f )+ 0.5f));


    }
    IEnumerator ShakeTime()
    {

        shake = true;

        yield return new WaitForSeconds(shakeTime);

        shake = false;
        



    }
}
