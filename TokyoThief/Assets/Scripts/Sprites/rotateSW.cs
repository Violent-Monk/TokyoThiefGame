using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSW : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform cam;
    Camera gameCam;
    SpriteRenderer[] sprites;
    public Sprite[] SWSprites;
    public Sprite[] NWSprites;
    string camDir = "NE";
    bool swap; // determine if we should change sprites because the camera rotated

    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponentsInChildren<SpriteRenderer>();
        cam = GameObject.Find("CameraObject").transform;
        gameCam = cam.GetComponentInChildren<Camera>();
        gameCam.transparencySortMode = TransparencySortMode.CustomAxis;
        gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // should probably move this to CamControls
        if (cam.rotation.eulerAngles.y > 275 || (cam.rotation.eulerAngles.y < 2 && cam.rotation.eulerAngles.y > -2))
        {
            swap = (camDir != "NE" ? true : false);
            camDir = "NE";
            gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);
        }
        else if (cam.rotation.eulerAngles.y > 1 && cam.rotation.eulerAngles.y < 135)
        {
            swap = (camDir != "SE" ? true : false);
            camDir = "SE";
            gameCam.transparencySortAxis = new Vector3(1f, 0f, -1f);
        }
        else if (cam.rotation.eulerAngles.y > 135 && cam.rotation.eulerAngles.y < 225)
        {
            swap = (camDir != "SW" ? true : false);
            camDir = "SW";
            gameCam.transparencySortAxis = new Vector3(-1f, 0f, -1f);
        }
        else
        {
            swap = (camDir != "NW" ? true : false);
            camDir = "NW";
            gameCam.transparencySortAxis = new Vector3(-1f, 0f, 1f);
        }



        Debug.Log(camDir + " " + swap + "  " + cam.rotation.eulerAngles.y);

        if (swap)
        {
            if (camDir == "SW")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = SWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.localPosition = new Vector3(-0.26f, 0.56f, 6.53f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.localPosition = new Vector3(0.49f, 0.56f, -6.958f);
                    }
                    else
                    {
                        //sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.5f, 0f, -0.2f);
                    }

                }
                sprites[0].sprite = SWSprites[SWSprites.Length - 1];
                sprites[sprites.Length - 1].sprite = SWSprites[0];
            }
            else if (camDir == "SE")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = NWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.localPosition = new Vector3(0.47f, 0.56f, 6.88f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.localPosition = new Vector3(-0.27f, 0.566f, -6.79f);
                    }
                    else
                    {
                        //sprites[i].transform.position = sprites[i].transform.position + new Vector3(2.5f, 0f, -0.2f);
                    }

                }
                sprites[0].sprite = NWSprites[0];
                sprites[sprites.Length - 1].sprite = NWSprites[NWSprites.Length - 1];

            }
            else if (camDir == "NW")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = NWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.localPosition = new Vector3(0.5f, 0.566f, 6.88f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.localPosition = new Vector3(-0.28f, 0.566f, -6.958f);
                    }
                    else
                    {
                        // sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }


                }
                sprites[0].sprite = NWSprites[NWSprites.Length - 1];
                sprites[sprites.Length - 1].sprite = NWSprites[0];
            }
            else if (camDir == "NE")
            {
                for (int i = 0; i < sprites.Length; ++i)
                {
                    sprites[i].sprite = SWSprites[i];
                    if (i == 0)
                    {
                        sprites[i].transform.localPosition = new Vector3(-0.26f, 0.566f, 6.88f);
                    }
                    else if (i == sprites.Length - 1)
                    {
                        sprites[i].transform.localPosition = new Vector3(0.45f, 0.566f, -6.79f);
                    }
                    else
                    {
                        //sprites[i].transform.position = sprites[i].transform.position - new Vector3(3.5f, 0f, -0.2f);
                    }


                }
                sprites[0].sprite = SWSprites[0];
                sprites[sprites.Length - 1].sprite = SWSprites[SWSprites.Length - 1];
            }
        }
    }

}
