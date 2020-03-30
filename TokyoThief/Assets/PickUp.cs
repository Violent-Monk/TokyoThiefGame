using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    float throwforce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    bool isHolding = true;

    // Update is called once per frame
    void Update()
    {

    	distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(isHolding == true){
        	item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        	item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.GetComponent<BoxCollider>().enabled = false;
        	item.transform.position = tempParent.transform.position + new Vector3(0f, 2f, 0f);

        	if(Input.GetMouseButtonDown(1)){
                isHolding = false;
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwforce);
                item.GetComponent<BoxCollider>().enabled = true;
            }
        }else{
        	objectPos = item.transform.position;
        	item.transform.SetParent(null);
        	item.GetComponent<Rigidbody>().useGravity = true;
        	item.transform.position = objectPos;
        }
    }
}