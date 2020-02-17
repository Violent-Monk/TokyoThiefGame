using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!flipped)
            {
                flipped = true;
                spriteRenderer.flipX = true;
                transform.position = transform.position + new Vector3(3.5f, 0f, -0.2f);
            }
            else
            {
                flipped = false;
                spriteRenderer.flipX = false;
                transform.position = transform.position + new Vector3(-3.5f, 0f, 0.2f);
            }


            
        }   

    }
}
