using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{

private AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {
		footsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     	if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)){
			footsteps.Play(); //footsteps on press
		}
		
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)){
			footsteps.Stop(); //NEED
		}
    }
}
