﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

	private AudioSource pickupitem;
    // Start is called before the first frame update
    void Start()
    {
        pickupitem = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
		//	if (item[i] = null | item[0] = true | item[1] = true){
			//	pickupitem.Play();
			//}
		}
    }
}
