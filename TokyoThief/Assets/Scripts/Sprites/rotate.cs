using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public bool flipped;
    public Transform cam;
    SpriteRenderer[] sprites;
    public Sprite[] SWSprites;
    public Sprite[] NWSprites;
    string camDir = "NE";
    bool swap; // determine if we should change sprites because the camera rotated

    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!flipped)
            {
                flipped = true;
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = SWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.7f, 0f, -0.9f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.5f, 0f, -0.2f);
                    }
                }
                
            }
            else
            {
                flipped = false;
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = NWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.7f, 0f, -0.9f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }
                }
                sprites[0].sprite = NWSprites[NWSprites.Length - 1];
                sprites[sprites.Length - 1].sprite = NWSprites[0];
            }           
        }   
        */

        if (cam.rotation.eulerAngles.y == 0)
        {
            swap = (camDir != "NE" ? true : false);
            camDir = "NE";
        }
        else if (cam.rotation.eulerAngles.y > 1)
        {
            swap = (camDir != "NW" ? true : false);
            camDir = "NW";
        }
        else if (cam.rotation.eulerAngles.y < -135)
        {
            swap = (camDir != "SW" ? true : false);
            camDir = "SW";
        }
        else
        {
            swap = (camDir != "SE" ? true : false);
            camDir = "SE";
        }

        Debug.Log(camDir + " " + swap);

        if (swap)
        {
            if (camDir == "SW")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = SWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.7f, 0f, -0.9f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                        sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.5f, 0f, -0.2f);
                    }
                }
            }
            else if (camDir == "SE")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = NWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.7f, 0f, -0.9f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }
                }
                sprites[0].sprite = NWSprites[NWSprites.Length - 1];
                sprites[sprites.Length - 1].sprite = NWSprites[0];
            }
            else if (camDir == "NW")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = SWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(-0.2f, 0f, 0.7f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                       // sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                       // sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }
                }
                sprites[0].sprite = SWSprites[0];
                sprites[sprites.Length - 1].sprite = SWSprites[SWSprites.Length - 1];
            }
            else if (camDir == "NE")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = NWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.7f, 0f, -0.9f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(2.22f, 0f, 0.47f);
                    }
                    else
                    {
                        sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }
                }
                sprites[0].sprite = NWSprites[NWSprites.Length - 1];
                sprites[sprites.Length - 1].sprite = NWSprites[0];
            }
        }
    }
        
}
