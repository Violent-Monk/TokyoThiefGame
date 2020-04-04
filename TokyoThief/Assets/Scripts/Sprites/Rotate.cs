using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform gameCam;
    CamControls cam;
    //Camera gameCam;
    GameObject spriteNE;
    GameObject spriteSE;
    GameObject spriteSW;
    GameObject spriteNW;
    GameObject currActive;

    CamControls camControls;
    //bool swap = false; // determine if we should change sprites because the camera rotated

    // Start is called before the first frame update
    void Start()
    {
        spriteNE = transform.GetChild(1).gameObject;
        spriteSE = transform.GetChild(2).gameObject;
        spriteSW = transform.GetChild(3).gameObject;
        spriteNW = transform.GetChild(4).gameObject;
        currActive = spriteNE;
        camControls = GameObject.Find("CameraObject").GetComponent<CamControls>();

        if (camControls.camDir != "NE")
        {
            swap(camControls.camDir);
        }

        currActive = spriteNE;
        cam = GameObject.Find("CameraObject").transform.GetComponent<CamControls>();

        swap(camControls.camDir);
        /* cam = GameObject.Find("CameraObject").transform;

         gameCam.transparencySortMode = TransparencySortMode.CustomAxis;
         gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);*/
    }

    public void swap(string camDir)
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
