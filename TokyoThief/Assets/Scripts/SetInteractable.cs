using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("HIT");
            CharControls controllerScript = other.GetComponent<CharControls>();
            controllerScript.setInteractable(GetComponent<Interactable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("UNHIT");
            CharControls controllerScript = other.GetComponent<CharControls>();
            controllerScript.setInteractable(null);
        }
    }
}
