using UnityEngine;
using TMPro;

public class LaternController : MonoBehaviour
{
    public GameObject lightObject; 
    public TextMeshProUGUI uiText; 
    public GameObject latern; 
    public GameObject roomWithDoor; 
    private bool isPlayerNear = false;

    void Start()
    {
        lightObject.SetActive(false);
        latern.SetActive(false);
        if (uiText != null)
        {
            uiText.gameObject.SetActive(false);
        }

        Debug.Log("LaternController initialized.");
    }

    void Update()
    {
        if (GameStateManager.Instance.puzzle2Solved)
        {
            Debug.Log("Puzzle 2 solved, activating Latern.");
            latern.SetActive(true); 

            if (uiText != null)
            {
                uiText.gameObject.SetActive(isPlayerNear); 
            }

            if (isPlayerNear && Input.GetKeyDown(KeyCode.R))
            {
                lightObject.SetActive(true); 
                if (uiText != null)
                {
                    uiText.gameObject.SetActive(false); 
                }

                if (roomWithDoor != null)
                {
                    roomWithDoor.SetActive(true);
                    Debug.Log("Room with door activated.");
                }
            }
        }
        else
        {
            latern.SetActive(false);
            if (uiText != null)
            {
                uiText.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player entered Latern trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (uiText != null)
            {
                uiText.gameObject.SetActive(false);
            }
            Debug.Log("Player exited Latern trigger area.");
        }
    }
}
