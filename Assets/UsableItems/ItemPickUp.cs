using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public UsableItem usableItem; 
    public GameObject itemPickupText;
    private bool playerInRange;
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
        if(playerInRange && Input.GetKeyDown(KeyCode.R)) { 

            Pickup();
            itemPickupText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemPickupText.SetActive(true);
            playerInRange = true;
        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemPickupText.SetActive(false);
            playerInRange = false;
        }
    }

}
