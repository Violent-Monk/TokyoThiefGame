using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWide : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        spriteNE = transform.GetChild(3).gameObject;
        spriteSE = transform.GetChild(4).gameObject;
        spriteSW = transform.GetChild(5).gameObject;
        spriteNW = transform.GetChild(6).gameObject;
        currActive = spriteNE;
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
