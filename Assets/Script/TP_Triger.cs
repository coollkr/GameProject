// 在 TeleportScript.cs 中
using UnityEngine;
using TMPro;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget; // Teleportation target location
    public TextMeshProUGUI enterRoomDialog; 
    public TextMeshProUGUI exitRoomDialog; 

    private bool playerInTrigger = false; // Check if the player is in the trigger zone

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.R))
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
            UpdateDialog(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            UpdateDialog(false);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (GameStateManager.Instance.AreAllPuzzlesSolved())
        {
            player.transform.position = teleportTarget.position; // Teleport the player!
            enterRoomDialog.text = "You solved all puzzles, time to run!";
        }
        else
        {
            enterRoomDialog.text = "Puzzle incomplete!";
        }
    }

    private void UpdateDialog(bool isActive)
    {
        if (isActive)
        {
            if (GameStateManager.Instance.AreAllPuzzlesSolved())
            {
                enterRoomDialog.gameObject.SetActive(true);
                enterRoomDialog.text = "Press R to teleport";
            }
            else
            {
                enterRoomDialog.gameObject.SetActive(true);
                enterRoomDialog.text = "Puzzle incomplete!";
            }
        }
        else
        {
            enterRoomDialog.gameObject.SetActive(false);
        }
    }
}
