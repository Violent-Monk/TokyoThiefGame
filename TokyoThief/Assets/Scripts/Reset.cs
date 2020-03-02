using UnityEngine;

// This script is used to reset scriptable objects
// back to their default values.
public class Reset : MonoBehaviour
{
    public ResettableScriptableObject[] resettableScriptableObjects;    // All of the scriptable object assets that should be reset at the start of the game.


    private void Awake()
    {
        // Go through all the scriptable objects and call their Reset function.
        for (int i = 0; i < resettableScriptableObjects.Length; i++)
        {
            resettableScriptableObjects[i].Reset();
        }
    }
}
