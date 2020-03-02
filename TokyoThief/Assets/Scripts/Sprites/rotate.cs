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
        if (cam.rotation.eulerAngles.y > 275 || (cam.rotation.eulerAngles.y < 45 && cam.rotation.eulerAngles.y > -2))
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
                currActive.SetActive(false);
                spriteSW.SetActive(true);
                currActive = spriteSW;
            }
            else if (camDir == "SE")
            {
                currActive.SetActive(false);
                spriteSE.SetActive(true);
                currActive = spriteSE;
            }
            else if (camDir == "NW")
            {
                currActive.SetActive(false);
                spriteNW.SetActive(true);
                currActive = spriteNW;
            }
            else if (camDir == "NE")
            {
                currActive.SetActive(false);
                spriteNE.SetActive(true);
                currActive = spriteNE;
            }
        }
    }

}
