using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This script is used to manipulate the items the player has
 *  and manipulate UI displaying
 */

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;   // the inventory itself
    public List<UsableItem> items = new List<UsableItem>(); // save the item list
    public GameObject inventoryUI; // UI to iteract with
    private int itemNumber;        // keep track of the number of items
    private void Awake()
    {
        instance = this;
        itemNumber = 0;
        
    }

    public void Start()
    {
        inventoryUI.SetActive(false);        // turn off the UI at the beginning
    }

    // add an item to the list
    public void Add(UsableItem item)
    {
        items.Add(item);          
        itemNumber++;
    }

    // remove the item from the list
    public void Remove(UsableItem item)
    {
        items.Remove(item);
        itemNumber--;
    }

    //return the item list 
    public List<UsableItem> getItems()
    {
        return items;
    }

    // return the number of items
    public int getItemNumber()
    {
        return itemNumber;
    }

    public void Update()
    {
        // when user press i, show/close the item UI
        if(Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryUI.activeSelf;
            inventoryUI.SetActive(!isActive);
        }
    }

}
