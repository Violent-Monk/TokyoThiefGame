using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour

{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int nextSpot;

    public Animator animator;

    public bool random;

    private bool investigating;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        investigating = false;

        if(random)
        {
            nextSpot = Random.Range(0, moveSpots.Length);
        }
        else
        {
            nextSpot = 0;
        }
        if (waitTime == 0)
        {
            animator.SetBool("Idle", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!(investigating)){
	        transform.position = Vector3.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);
	        transform.LookAt(moveSpots[nextSpot].position);
	        animator.SetFloat("Direction", transform.rotation.eulerAngles.y);

	        if (Vector3.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f)
	        {
	            if(waitTime <= 0){
	                if (random)
	                {
	                    nextSpot = Random.Range(0, moveSpots.Length);
	                }
	                else if (nextSpot == moveSpots.Length - 1)
	                {
	                    nextSpot = 0;
	                }
	                else
	                {
	                    nextSpot++;
	                }
	                waitTime = startWaitTime;
	                animator.SetBool("Idle", false);
	            } else {
	                waitTime -= Time.deltaTime;
	                animator.SetBool("Idle", true);
	            }
	        }
	    }
    }

   public void investigate(Transform location){
    	investigating = true;
    	transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime);
    	transform.LookAt(location.position);
        //animator.SetFloat("Direction", transform.rotation.eulerAngles.y);
    	investigating = false;

    }
}
