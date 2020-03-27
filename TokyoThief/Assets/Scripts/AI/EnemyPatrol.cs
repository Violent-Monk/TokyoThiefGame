using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    FoV fov;

    Vector3 nextLoc;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        cam = GameObject.Find("CameraObject").transform;
        fov = GetComponentInChildren<FoV>();

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
                investStarted = true;
                nextLoc = investLoc.position;
                nextLoc.y = 3.3f; // stop guards from moving up or down
                waiting = true;
                animator.SetBool("Idle", true);
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
        transform.position = Vector3.MoveTowards(transform.position, nextLoc, speed * Time.deltaTime);
        transform.LookAt(nextLoc);
        animator.SetFloat("Direction", Mathf.Repeat(transform.rotation.eulerAngles.y - cam.rotation.eulerAngles.y, 360));

        if (Vector3.Distance(transform.position, nextLoc) < 0.2f)
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
                animator.SetBool("Idle", false);
            }
            else
            {
                waitTime -= Time.deltaTime;
                animator.SetBool("Idle", true);
            }
        }
    }

    void investigate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextLoc, speed * Time.deltaTime);
        fov.viewAngle = 200;
        transform.LookAt(nextLoc);
        animator.SetFloat("Direction", Mathf.Repeat(transform.rotation.eulerAngles.y - cam.rotation.eulerAngles.y, 360));

        if (transform.position == nextLoc)
        {
            if (investTime <= 0)
            {
                investTime = startInvestTime;
                animator.SetBool("Idle", false);
                stateAnimator.SetBool("Caution", false);
                investigating = false;
                investStarted = false;
                fov.viewAngle = 70;
            }
            else
            {
                investTime -= Time.deltaTime;
                animator.SetBool("Idle", true);
            }
        }
    }

    IEnumerator wait()
    {
        // give the player a chance to get away
        yield return new WaitForSeconds(2);
        animator.SetBool("Idle", false);
        waiting = false;
    }
}
