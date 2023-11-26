using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<UsableItem> items = new List<UsableItem>();
    public GameObject inventoryUI;
    private int itemNumber;
    private void Awake()
    {
        instance = this;
        itemNumber = 0;
        
    }

    public void Start()
    {
        inventoryUI.SetActive(false); 
    }

    public void Add(UsableItem item)
    {
        items.Add(item);
        itemNumber++;
    }

    public void Remove(UsableItem item)
    {
        items.Remove(item);
        itemNumber--;
    }

    public List<UsableItem> getItems()
    {
        return items;
    }

    public int getItemNumber()
    {
        return itemNumber;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            bool isActive = inventoryUI.activeSelf;
            inventoryUI.SetActive(!isActive);
        }
    }

}
