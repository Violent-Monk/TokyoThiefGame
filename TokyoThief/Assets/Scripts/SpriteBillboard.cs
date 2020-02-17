using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpriteBillboard : MonoBehaviour
{
    Camera m_Camera;
    static bool isNormal = false;

    private void Awake()
    {
        m_Camera = Camera.main;
    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        if(!isNormal)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
             m_Camera.transform.rotation * Vector3.up);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
            
    }
}