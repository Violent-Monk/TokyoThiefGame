using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour

{

    public float speed;
    private float waitTime;
    private float investTime;
    public float startWaitTime;
    private float startInvestTime = 2f;
    Transform cam;

    public Transform[] moveSpots;
    private int nextSpot;

    public Animator animator;
    public Animator stateAnimator;

    public bool random;

    public bool investigating;
    public bool waiting;
    public Transform investLoc;
    bool investStarted;

    NavMeshAgent agent;

    FoV fov;

    Vector3 nextLoc;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        cam = GameObject.Find("CameraObject").transform;
        fov = GetComponentInChildren<FoV>();
        agent = GetComponent<NavMeshAgent>();

        investLoc = null;
        waiting = false;
        investigating = false;
        investStarted = false;
        investTime = startInvestTime;

        if (random)
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
        if (agent.isStopped)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }
        if (investigating == false)
        {
            nextLoc = moveSpots[nextSpot].position;
            patrol();
        }
        else
        {          
            stateAnimator.SetBool("Caution", true);
            if (!investStarted) // the guard has just noticed the player
            {
                agent.isStopped = true;
                investStarted = true;
                nextLoc = investLoc.position;
                waiting = true;
                StartCoroutine(wait());
            }
            else if (!waiting)
            {
                investigate();
            }
            
        }
        
    }

    void patrol()
    {
        //transform.position = Vector3.MoveTowards(transform.position, nextLoc, speed * Time.deltaTime);

        
            agent.destination = nextLoc;
            
        
        //transform.LookAt(nextLoc);
        animator.SetFloat("Direction", Mathf.Repeat(transform.rotation.eulerAngles.y - cam.rotation.eulerAngles.y, 360));

        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            if (waitTime <= 0)
            {
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
                agent.isStopped = false;
            }
            else
            {
                agent.isStopped = true;
                waitTime -= Time.deltaTime;
            }
        }
    }

    void investigate()
    {
        // transform.position = Vector3.MoveTowards(transform.position, nextLoc, speed * Time.deltaTime);
        if (agent.destination != nextLoc)
        {
            agent.destination = nextLoc;
            agent.isStopped = false;
            agent.autoBraking = true;
        }   
        fov.viewAngle = 200;
        animator.SetFloat("Direction", Mathf.Repeat(transform.rotation.eulerAngles.y - cam.rotation.eulerAngles.y, 360));

        if (agent.remainingDistance == 0f)
        {
            agent.isStopped = true;
            if (investTime <= 0)
            {
                investTime = startInvestTime;
                agent.isStopped = false;
                stateAnimator.SetBool("Caution", false);
                investigating = false;
                investStarted = false;
                fov.viewAngle = 70;
                agent.autoBraking = false;
            }
            else
            {
                investTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator wait()
    {
        // give the player a chance to get away
        yield return new WaitForSeconds(2);
        waiting = false;
    }
}
