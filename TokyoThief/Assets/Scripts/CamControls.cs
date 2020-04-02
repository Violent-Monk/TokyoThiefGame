using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour
{
    public GameObject player; //Move player Prefab into this slot to lock camera onto player
    Transform target;

    public float smoothSpeed = 0.125f; //Camera smooth movement speed

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    Quaternion turnAngle;

    Transform cam;

    public string camDir = "NE";

    public bool swap = false;

    Camera gameCam;

    // Start is called before the first frame update
    void Start()
    {
        turnAngle = transform.rotation;
        target = player.transform;
        cam = GameObject.Find("CameraObject").transform;
        gameCam = cam.GetComponentInChildren<Camera>();
        gameCam.transparencySortMode = TransparencySortMode.CustomAxis;
        gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position; //makes camera focus on player target

        if (transform.rotation == turnAngle)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                turnAngle *= Quaternion.AngleAxis(90, Vector3.up);
                switch (camDir)
                {
                    case "NE":
                        camDir = "SE";
                        gameCam.transparencySortAxis = new Vector3(1f, 0f, -1f);
                        break;
                    case "SE":
                        camDir = "SW";
                        gameCam.transparencySortAxis = new Vector3(-1f, 0f, -1f);
                        break;
                    case "SW":
                        camDir = "NW";
                        gameCam.transparencySortAxis = new Vector3(-1f, 0f, 1f);
                        break;
                    case "NW":
                        camDir = "NE";
                        gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);
                        break;
                    
                }
                swap = true;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                turnAngle *= Quaternion.AngleAxis(-90, Vector3.up);
                switch (camDir)
                {
                    case "NE":
                        camDir = "NW";
                        gameCam.transparencySortAxis = new Vector3(-1f, 0f, 1f);
                        break;
                    case "SE":
                        camDir = "NE";
                        gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);
                        break;
                    case "SW":
                        camDir = "SE";
                        gameCam.transparencySortAxis = new Vector3(1f, 0f, -1f);
                        break;
                    case "NW":
                        camDir = "SW";
                        gameCam.transparencySortAxis = new Vector3(-1f, 0f, -1f);
                        break;
                }
                swap = true;
            }
        }
        Rotate();
    }

    void Rotate()
    {
        if (swap)
        {
            foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Wall"))
            {
                if (wall.GetComponent<Rotate>() == null)
                {
                    Debug.LogError(wall.name + " has the wrong tag!");
                }
                else
                {
                    wall.GetComponent<Rotate>().swap(camDir);
                }
                
                
            }
            foreach (GameObject wall in GameObject.FindGameObjectsWithTag("WallWide"))
            {
                if (wall.GetComponent<RotateWide>() == null)
                {
                    Debug.LogError(wall.name + " has the wrong tag!");
                }
                else
                {
                    wall.GetComponent<RotateWide>().swap(camDir);
                }       
            }
        }
        swap = false;
        transform.rotation = Quaternion.Slerp(transform.rotation, turnAngle, smoothFactor);
    }
}
