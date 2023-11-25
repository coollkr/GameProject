using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    public Transform characterModel; 

    void Start()
    {
        // Finding the main camera containing the mouselook script
        mouselook cameraLookScript = FindObjectOfType<mouselook>();
        if (cameraLookScript != null && characterModel != null)
        {
            cameraLookScript.characterModel = characterModel;
            Debug.Log("Character model set in mouselook script");
        }
        else
        {
            Debug.LogError("mouselook script or character model not found");
        }
    }
}
