using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Transform gameCam;
    CamControls cam;
    GameObject spriteNE;
    GameObject spriteSE;
    GameObject spriteSW;
    GameObject spriteNW;
    GameObject currActive;

    CamControls camControls;

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
    }

    // swap to the appropriate sprite set for the new camera angle
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
