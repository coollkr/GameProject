using UnityEngine;
using TMPro;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget; // Teleportation target location
    public GameObject player; // player
    public GameObject enterRoomDialog; 
    public GameObject exitRoomDialog; 

    private bool playerInTrigger = false; // check the player is in the trigger zone or not

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
            TeleportPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTrigger = true;
            if (enterRoomDialog != null) ActivateDialog(enterRoomDialog, true);
            if (exitRoomDialog != null) ActivateDialog(exitRoomDialog, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInTrigger = false;
            if (enterRoomDialog != null) ActivateDialog(enterRoomDialog, false);
            if (exitRoomDialog != null) ActivateDialog(exitRoomDialog, false);
        }
    }


    /*The important things in here is,
    I Disable all the colliders before TP
    If I dont disable, Then MC can not be TP to other place bacause of Coolder
    */
    private void TeleportPlayer()
    {
        Collider playerCollider = player.GetComponent<Collider>();
        if (playerCollider != null) 
        {
            playerCollider.enabled = false; // Disable colliders before teleportation
        }

        player.transform.position = teleportTarget.position; // TP!

        if (playerCollider != null) 
        {
            playerCollider.enabled = true; // Re-enable collider after transmission
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
