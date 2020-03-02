using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform cam;
    Camera gameCam;
    SpriteRenderer[] sprites;
    GameObject spriteNE;
    GameObject spriteSE;
    GameObject spriteSW;
    GameObject spriteNW;
    GameObject currActive;
    string camDir = "NE";
    bool swap; // determine if we should change sprites because the camera rotated

    // Start is called before the first frame update
    void Start()
    {
        spriteNE = transform.GetChild(1).gameObject;
        spriteSE = transform.GetChild(2).gameObject;
        spriteSW = transform.GetChild(3).gameObject;
        spriteNW = transform.GetChild(4).gameObject;
        currActive = spriteNE;
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

        if (swap)
        {
            if (camDir == "SW")
            {
                /*for (int i = 0; i < sprites.Length; ++i)
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
                sprites[sprites.Length - 1].sprite = SWSprites[0];*/
                currActive.SetActive(false);
                spriteSW.SetActive(true);
                currActive = spriteSW;
            }
            else if (camDir == "SE")
            {
                /* for (int i = 0; i < sprites.Length; ++i)
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
                 sprites[sprites.Length - 1].sprite = NWSprites[NWSprites.Length - 1];*/
                currActive.SetActive(false);
                spriteSE.SetActive(true);
                currActive = spriteSE;
            }
            else if (camDir == "NW")
            {
                /*for (int i = 0; i < sprites.Length; ++i)
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
                sprites[sprites.Length - 1].sprite = NWSprites[0];*/
                currActive.SetActive(false);
                spriteNW.SetActive(true);
                currActive = spriteNW;
            }
            else if (camDir == "NE")
            {
                /* for (int i = 0; i < sprites.Length; ++i)
                 {
                     sprites[i].sprite = SWSprites[i];
                     if (i == 0)
                     {
                         sprites[i].transform.localPosition = new Vector3(0.05f, 0.566f, 5.96f);
                     }
                     else if (i == sprites.Length - 1)
                     {
                         sprites[i].transform.localPosition = new Vector3(0.59f, 0.84f, -9.22f);
                     }

                 }
                 sprites[0].sprite = SWSprites[0];
                 sprites[sprites.Length - 1].sprite = SWSprites[SWSprites.Length - 1];*/
                currActive.SetActive(false);
                spriteNE.SetActive(true);
                currActive = spriteNE;
            }
        }
    }

}
