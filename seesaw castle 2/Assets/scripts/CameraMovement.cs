using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float horizontalSpeed = 0.15f;
    public float verticalSpeed = 0.2f;
    public float zoomSpeed = 0.15f;
    public int bottom = -2;
    public float zoomOutLimit = 10;
    public float zoomInLimit = 1;
    public int topDivide = 4;
    public int horizontalLock = 10;

    private GameObject go;
    private Camera mycam;
    private SpawnTowers spawnTowers;

    // Use this for initialization
    void Start () {
        spawnTowers = GameObject.Find("beam 1").GetComponent<SpawnTowers>();
        go = GameObject.Find("Main Camera");
        mycam = GetComponent<Camera>();
        ChangeRes();
        //zoomOutLimit = //zoomOutLimit * Screen.width/100;



    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKey("w")&& go.transform.position.y < spawnTowers.highest/ topDivide) {
            Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y + verticalSpeed, go.transform.position.z);
            go.transform.position = pos;

        }
        if (Input.GetKey("s")&&go.transform.position.y>bottom)
        {
            Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y - verticalSpeed, go.transform.position.z);
            go.transform.position = pos;

        }
        if (Input.GetKey("a") && go.transform.position.x > -horizontalLock)
        {
            Vector3 pos = new Vector3(go.transform.position.x - horizontalSpeed, go.transform.position.y, go.transform.position.z);
            go.transform.position = pos;

        }
        if (Input.GetKey("d") && go.transform.position.x < horizontalLock)
        {
            Vector3 pos = new Vector3(go.transform.position.x + horizontalSpeed, go.transform.position.y, go.transform.position.z);
            go.transform.position = pos;

        }
        float wheel = Input.GetAxis("Mouse ScrollWheel");
       
        if (wheel > 0f && mycam.orthographicSize > zoomInLimit) {
            //Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z + wheel);
            //go.transform.position = pos;
            mycam.orthographicSize -= zoomSpeed;


        }
        else if (wheel < 0f&& mycam.orthographicSize<zoomOutLimit)
        {
            //Vector3 pos = new Vector3(go.transform.position.x, go.transform.position.y, go.transform.position.z - wheel);
            //go.transform.position = pos;
            mycam.orthographicSize += zoomSpeed;


        }
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;
            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
            // If the camera is orthographic...
            // if (camera.isOrthoGraphic)
         
                // ... change the orthographic size based on the change in distance between the touches.

            float orth = Camera.main.orthographicSize + deltaMagnitudeDiff * zoomSpeed/10;
            //Debug.Log("debuglol " + orth);
            if (orth<zoomOutLimit && orth>0f) {
                Camera.main.orthographicSize=orth;

            }
            //Debug.Log("debuglol "+deltaMagnitudeDiff);
            if (touchZero.phase == TouchPhase.Moved && touchOne.phase == TouchPhase.Moved && deltaMagnitudeDiff >-10 && deltaMagnitudeDiff < 10)
            {
                Vector2 touchDeltaPosition = touchZero.deltaPosition;
                Debug.Log(touchDeltaPosition);
                if (touchDeltaPosition.x <0 && go.transform.position.x < horizontalLock) {
                    transform.Translate(-touchDeltaPosition.x * horizontalSpeed / 5,0, 0);
                }
                if (touchDeltaPosition.x > 0 && go.transform.position.x > -horizontalLock)
                {
                    transform.Translate(-touchDeltaPosition.x * horizontalSpeed / 5, 0, 0);
                }
                if (touchDeltaPosition.y > 0 && go.transform.position.y > bottom)
                {
                    transform.Translate(0,-touchDeltaPosition.y * verticalSpeed / 5, 0);
                }
                if (touchDeltaPosition.y < 0 && go.transform.position.y < spawnTowers.highest / topDivide)
                {
                    transform.Translate(0, -touchDeltaPosition.y * verticalSpeed / 5, 0);
                }
            }

            // Make sure the orthographic size never drops below zero.
            // Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);

        }

        }
    public void ChangeRes() {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        zoomOutLimit = 1920 / currentAspect / 110;
        //zoomOutLimit = Screen.height / (2 * 32f);
        //zoomOutLimit=Screen.height/100
        // Calculating ortographic width
        //float orthoWidth = 5f / Screen.height * Screen.width;
        // Setting aspect ration
        //orthoWidth = orthoWidth / ((9f / 16f) / mycam.aspect);
        // Setting Size
        //zoomOutLimit = (orthoWidth / Screen.width * Screen.height);


        
    }
}
