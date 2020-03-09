using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardsteps : MonoBehaviour
{

	private AudioSource guardswalk;
	
    // Start is called before the first frame update
    void Start()
    {
        guardswalk = GetComponent<AudioSource>(); 
		guardswalk.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
