using UnityEngine;
using UnityEngine.UI;

public class TriggerExample : MonoBehaviour
{
    public Text promptText; // Assign this in the inspector

    private void Start()
    {
        // Make sure the text is not visible at the start
        promptText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player entering the trigger
        {
            promptText.enabled = true; // Show the text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player leaving the trigger
        {
            promptText.enabled = false; // Hide the text
        }
    }
}
