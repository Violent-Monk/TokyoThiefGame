using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardFootsteps : MonoBehaviour
{

private AudioSource guards;
public AudioRolloffMode Linear;
    // Start is called before the first frame update
    void Start()
    {
        guards = GetComponent<AudioSource>();
		guards.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
