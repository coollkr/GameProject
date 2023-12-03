using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script controls the item picking up function
 * It displays the text when the player gets closed to the item
 * and update the item list when user picks the item up
 */
public class ItemPickUp : MonoBehaviour
{

    public UsableItem usableItem; 
    public GameObject itemPickupText;
    private bool playerInRange;

    // When the item is picked, disable this item
    void Pickup()
    {
        InventoryManager.instance.Add(usableItem);
        gameObject.SetActive(false);
    }

    public void Start()
    {
        playerInRange = false;
    }

    
    public void Update()
    {
        // when the player is in the range of the item and presses r, the item is picked up
        // and the UI will disappear
        if(playerInRange && Input.GetKeyDown(KeyCode.R)) { 

            Pickup();
            itemPickupText.SetActive(false);
        }
    }

    // When player collides the item, show text 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemPickupText.SetActive(true);
            playerInRange = true;
        }
    
    }

    // When player collides the item, remove text 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemPickupText.SetActive(false);
            playerInRange = false;
        }
    }

}
