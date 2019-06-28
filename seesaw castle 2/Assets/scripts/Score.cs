using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int Score_=0;
    public int startGold = 100;
    private int gold;
    public float goldTime = 5;
    public int goldper=1;
    public Text scoreText;
    public Text goldText;
    public int scoreDiv;

    private bool ready=true;
    // Use this for initialization
    void Start () {
        gold = startGold;
        goldText.text = "GOLD : " + gold;
    }
	
	// Update is called once per frame
	void Update () {
        if (ready) {
            StartCoroutine(GoldOverTime());
        }
       
	}
    public void AddScore(int scoreAdd) {
        Score_ += scoreAdd;
        scoreText.text = "SCORE : "+Score_;

    }

    public int GetScore() {
        return Score_;

    }

    public int GetGold()
    {
        return gold;

    }
    public void AddGold(int goldAdd)
    {
        gold += goldAdd;
        goldText.text = "GOLD : " + gold;

    }
    IEnumerator GoldOverTime()
    {

        ready = false;

        yield return new WaitForSeconds(goldTime);
        if (scoreDiv != 0)
        {
            AddGold(goldper + (int)Score_ / scoreDiv);

        }
        else {
            AddGold(goldper);
        }
       

        ready = true;


    }
}
