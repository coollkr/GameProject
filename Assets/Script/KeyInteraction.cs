using UnityEngine;
using TMPro;

public class KeyInteraction : MonoBehaviour
{
    public GameObject uiTextObject; 
    public bool isKeyObtained = false; // Indicates if you have the key.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiTextObject.SetActive(false); 
    }
    }

    private void Update()
    {
        if (uiTextObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            GetKey();
        }
    }

    private void GetKey()
    {
        isKeyObtained = true; //  Setting the key to the Acquired state
        gameObject.SetActive(false);
        uiTextObject.SetActive(false);
    }
}

