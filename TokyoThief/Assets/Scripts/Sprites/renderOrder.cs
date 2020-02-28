using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderOrder : MonoBehaviour
{
    public GameObject sprite;
    public Transform obj;
    public Transform player;
    SpriteRenderer spriteRenderer;
    public bool axis = false; // false == NWSE, true == NESW

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (axis)
        {
            //spriteRenderer.sortingOrder = (int)(player.position.x - obj.position.x);
            
             spriteRenderer.sortingOrder = (int)(player.position.x - transform.position.x);
            
        }
        else
        {
            spriteRenderer.sortingOrder = (int)(player.position.z - transform.position.z);     
        }
    }
}
