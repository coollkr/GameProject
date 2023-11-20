using UnityEngine;
using TMPro;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget; // Teleportation target location
    public GameObject enterRoomDialog; 
    public GameObject exitRoomDialog; 

    private bool playerInTrigger = false; // Check the player is in the trigger zone or not

    void Start()
    {
        // Make sure the dialog box is not displayed at first
        ActivateDialog(enterRoomDialog, false);
        ActivateDialog(exitRoomDialog, false);
    }

    void Update()
    {
        // Check if the player is in the trigger zone and has pressed the F key
        if (playerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                TeleportPlayer(player);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            ActivateDialog(enterRoomDialog, true);
            ActivateDialog(exitRoomDialog, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            ActivateDialog(enterRoomDialog, false);
            ActivateDialog(exitRoomDialog, false);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (playerCollider != null) 
        {
            playerCollider.enabled = false; // Disable colliders before teleportation
        }

        player.transform.position = teleportTarget.position; // Teleport the player!

        if (playerCollider != null) 
        {
            playerCollider.enabled = true; // Re-enable collider after teleportation
        }
    }

    private void ActivateDialog(GameObject dialog, bool isActive)
    {
        if (dialog != null)
        {
            dialog.SetActive(isActive);
            ToggleTextMeshPro(dialog, isActive);
        }
    }

    private void ToggleTextMeshPro(GameObject dialog, bool isActive)
    {
        TextMeshProUGUI tmpText = dialog.GetComponentInChildren<TextMeshProUGUI>(true); 
        if (tmpText != null)
        {
            tmpText.gameObject.SetActive(isActive);
        }
    }
}
