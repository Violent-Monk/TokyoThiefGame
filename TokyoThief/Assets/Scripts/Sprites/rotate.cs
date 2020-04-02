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
    //string camDir = "NE";
    //bool swap = false; // determine if we should change sprites because the camera rotated

    // Start is called before the first frame update
    void Start()
    {
        spriteNE = transform.GetChild(1).gameObject;
        spriteSE = transform.GetChild(2).gameObject;
        spriteSW = transform.GetChild(3).gameObject;
        spriteNW = transform.GetChild(4).gameObject;

        currActive = spriteNE;
        cam = GameObject.Find("CameraObject").transform.GetComponent<CamControls>();
        /* cam = GameObject.Find("CameraObject").transform;

         gameCam.transparencySortMode = TransparencySortMode.CustomAxis;
         gameCam.transparencySortAxis = new Vector3(1f, 0f, 1f);*/
    }

    public void swap(string camDir)
    {
        if (camDir == "SW")
        {
            Debug.Log("swapping " + gameObject.name + " to SW");
            currActive.SetActive(false);
            spriteSW.SetActive(true);
            currActive = spriteSW;
        }
        else if (camDir == "SE")
        {
            Debug.Log("swapping to SE");
            currActive.SetActive(false);
            spriteSE.SetActive(true);
            currActive = spriteSE;
        }
        else if (camDir == "NW")
        {
            Debug.Log("swapping to NW");
            currActive.SetActive(false);
            spriteNW.SetActive(true);
            currActive = spriteNW;
        }
        else if (camDir == "NE")
        {
            Debug.Log("swapping to NE");
            currActive.SetActive(false);
            spriteNE.SetActive(true);
            currActive = spriteNE;
        }
    }

}
