using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour
{
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    Quaternion turnAngle;

    // Start is called before the first frame update
    void Start()
    {
        turnAngle = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
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
