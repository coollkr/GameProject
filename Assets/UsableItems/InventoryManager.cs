using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<UsableItem> items = new List<UsableItem>();
    private void Awake()
    {
        instance = this; 
    }

    public void Add(UsableItem item)
    {
        items.Add(item);
    }

    public void Remove(UsableItem item)
    {
        items.Remove(item);
    }

    public List<UsableItem> getItems()
    {
        return items;
    }

}
