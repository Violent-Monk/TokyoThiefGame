using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{

private AudioSource clickoption;
    // Start is called before the first frame update
    void Start()
    {
        clickoption = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
			clickoption.Play();
		}
		if (Input.GetMouseButtonUp(0)) {
			clickoption.Stop();
		}
    }
}
