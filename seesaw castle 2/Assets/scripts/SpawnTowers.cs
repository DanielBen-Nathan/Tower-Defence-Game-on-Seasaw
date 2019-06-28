using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTowers : MonoBehaviour {

    public GameObject selectedTower;
    public List<GameObject> towers = new List<GameObject>();
    private float archerTowerSizeX = 1.1f;
    private float archerTowerSizeY = 0.95f;
    public float highest=15;
    public float hightInc = 15;
    private bool ready = true;
    public float waitTime = 0.5f;
    private Score scoreScript;
    
    public float placementBound = 9.5f;
    public Button gameScreen;
    private bool onGame = false;
    private Vector2 worldPoint;
    private int actualCost;

    private bool fingerValid = true;
    private float fingerTime = 0f;
    private float timeout = 0.2f;
    
    // Use this for initialization
    void Start () {
        scoreScript = GameObject.Find("beam 1").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update() {

        selectedTower = gameObject.GetComponent<TowerSelector>().GetTower();


        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(p);
        //Debug.Log(ready);
        actualCost = selectedTower.GetComponent<Tower>().cost + (int)(Mathf.Abs(worldPoint.x) + 0.5f);
        // Debug.Log((Input.GetMouseButtonDown(0)));
        // Debug.Log("debuglol " + Input.touchCount);
        //Debug.Log(Input.mousePosition);
        //Debug.Log(GameObject.Find("TowerPicker").transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y);
        //float UILowerLimit = GameObject.Find("TowerPicker").transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta.y * GameObject.Find("TowerPicker").transform.localScale.y;
        if (ready == true && worldPoint.x > -placementBound && worldPoint.x < placementBound &&CheckPositions()){//&&UILowerLimit<Input.mousePosition.y) {

            if (Input.GetMouseButtonDown(0) && Application.platform != RuntimePlatform.Android) {
                PlaceTower();
            }
            if (Application.platform == RuntimePlatform.Android)
            {
                Touch touch = Input.GetTouch(0);
                if (Input.touchCount == 1 && touch.phase == TouchPhase.Began) {
                    StartCoroutine(WaitFinger());
                     


                }
            }

        }
        //Touch touch = Input.GetTouch(0);
      //  if (((Input.GetMouseButtonDown(0) && Application.platform != RuntimePlatform.Android) || (Input.touchCount == 1 && touch.phase == TouchPhase.Began)) && ready == true && worldPoint.x > -placementBound && worldPoint.x < placementBound)
      //  {
           // if (fingerValid)
          //  {

              //  fingerTime += Time.deltaTime;
         //   }
          //  if (fingerTime > timeout)
          //  {

            //    fingerTime = 0;
             //   fingerValid = false;


         //   }



       // }

    }

    public void PlaceTower() {
     
      

            if (scoreScript.GetGold() >= actualCost)
            {
                scoreScript.AddGold(-actualCost);




                bool placeable = true;

                for (int i = 0; i < towers.ToArray().Length; i++)
                {
                    // Debug.Log(worldPoint.x +"  "+ towers[i].transform.position.x);
                    //if (worldPoint.x- archerTowerSizeX < towers[i].transform.position.x && worldPoint.x+ archerTowerSizeX > towers[i].transform.position.x 
                    // && worldPoint.y - archerTowerSizeY < towers[i].transform.position.y && worldPoint.y + archerTowerSizeY > towers[i].transform.position.y) {
                    //placeable = false;
                    // Debug.Log("cannot place");

                    //}
                    //Debug.Log(towers[i].GetComponent<Rigidbody2D>().velocity.y );
                    if (towers[i].transform.position.y > highest - 5 && towers[i].GetComponent<Rigidbody2D>().velocity.y - 0.5 < 0 && towers[i].GetComponent<Rigidbody2D>().velocity.y + 0.5 > 0)
                    {
                        highest = towers[i].transform.position.y + hightInc;
                    }
                    //highest = highest + 0.f;




                }


                //Debug.Log(highest);
                if (placeable)
                {
                    GameObject archerTowerObj = Instantiate(selectedTower, new Vector2(worldPoint.x, highest), transform.rotation);
                    towers.Add(archerTowerObj);
                }

                StartCoroutine(WaitBetweenSpawns());


            }
            else
            {
                //Debug.Log("cost too much");
            }

        



    }
    IEnumerator WaitFinger()
    {

        yield return new WaitForSeconds(timeout);
        if (Input.touchCount == 1) {
            //fingerValid = false;
            PlaceTower();

        }

    }


        IEnumerator WaitBetweenSpawns()
    {
       
        ready = false;
       
        yield return new WaitForSeconds(waitTime);
       
        ready = true;



    }
    public void RemoveTower(GameObject tower)
    {
        for (int i = 0; i < towers.ToArray().Length; i++)
        {
            if (towers[i] == tower) {
                Destroy(towers[i]);
                towers.RemoveAt(i);
               
            }



        }
    }

    private bool CheckPositions() {
        if (!GetComponent<UserInterface>().paused && !GetComponent<UserInterface>().over) {
            bool towerPickerTop = CheckPositionYLower(GameObject.Find("TowerPicker").transform.GetChild(0).gameObject, GameObject.Find("TowerPicker"));
            bool towerPickerRight = CheckPositionXLowerHalf(GameObject.Find("TowerPicker").transform.GetChild(0).gameObject, GameObject.Find("TowerPicker"));
            bool towerPickerLeft = CheckPositionXHigherHalf(GameObject.Find("TowerPicker").transform.GetChild(0).gameObject, GameObject.Find("TowerPicker"));

            bool menuButtonBottom = CheckPositionYHigher(GameObject.Find("TopDisplay").transform.GetChild(1).gameObject, GameObject.Find("TopDisplay"));
            bool menuButtonLeft = CheckPositionXHigher(GameObject.Find("TopDisplay").transform.GetChild(1).gameObject, GameObject.Find("TopDisplay"));


            return (towerPickerTop || towerPickerLeft || towerPickerRight) && (menuButtonBottom || menuButtonLeft);

        }

        return false;

    }

    private bool CheckPositionYLower(GameObject go, GameObject canvas)
    {
        float UILimit = go.GetComponent<RectTransform>().sizeDelta.y * canvas.transform.localScale.y + go.transform.position.y;
        //Debug.Log(UILimit);
        return UILimit < Input.mousePosition.y;

    }
    private bool CheckPositionYHigher(GameObject go, GameObject canvas)
    {
        float UILimit = -go.GetComponent<RectTransform>().sizeDelta.y * canvas.transform.localScale.y + go.transform.position.y;
        //Debug.Log(UILimit);
        return UILimit > Input.mousePosition.y;

    }

    private bool CheckPositionXLowerHalf(GameObject go, GameObject canvas)
    {
        float UILimit = go.GetComponent<RectTransform>().sizeDelta.x/2* canvas.transform.localScale.x + go.transform.position.x;
        //Debug.Log(UILimit);
        return UILimit < Input.mousePosition.x;

    }
    private bool CheckPositionXHigherHalf(GameObject go, GameObject canvas)
    {
        float UILimit = -go.GetComponent<RectTransform>().sizeDelta.x/2 * canvas.transform.localScale.x+go.transform.position.x;
        //Debug.Log(UILimit);
        return UILimit > Input.mousePosition.x;

    }
    private bool CheckPositionXHigher(GameObject go, GameObject canvas)
    {
        float UILimit = -go.GetComponent<RectTransform>().sizeDelta.x * canvas.transform.localScale.x + go.transform.position.x;
        //Debug.Log(UILimit);
        return UILimit > Input.mousePosition.x;

    }

}
