using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiroFootsteps : MonoBehaviour
{

private AudioSource hiro;

    // Start is called before the first frame update
    void Start()
    {
        hiro = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
			hiro.Play();
		}
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
			hiro.Stop();
		}
    }
}
