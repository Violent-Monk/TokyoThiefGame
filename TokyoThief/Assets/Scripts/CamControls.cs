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

    // Start is called before the first frame update
    void Start()
    {
        turnAngle = transform.rotation;
        target = player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position; //makes camera focus on player target

        if (transform.rotation == turnAngle)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                turnAngle *= Quaternion.AngleAxis(90, Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                turnAngle *= Quaternion.AngleAxis(-90, Vector3.up);
            }
        }
        Rotate();
    }

    void Rotate()
    {    
        transform.rotation = Quaternion.Slerp(transform.rotation, turnAngle, smoothFactor);
    }
}
