using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public InventoryManager manager;
    private List<UsableItem> items;
    private List<Transform> itemDisplay;

    public void Start()
    {
        itemDisplay = new List<Transform>();

        foreach(Transform child in transform)
        {
            itemDisplay.Add(child);
        }

    }
    void Update()
    {
        items = manager.getItems();

        for (int i = 0; i < items.Count; i++)
        {
            if (itemDisplay[i] == null)
            {
                Debug.Log("No child Button.");
            }

            Transform itemNameTransform = itemDisplay[i].transform.Find("ItemName");
            if(itemNameTransform == null) {
                Debug.Log("No ItemName");
            }

            TMPro.TextMeshProUGUI itemNameText = itemNameTransform.GetComponent<TMPro.TextMeshProUGUI>();
            
            if (itemNameText != null)
            {
                itemNameText.text = items[i].itemName;
            }

            Transform iconTransform = itemDisplay[i].transform.Find("Icon");
            Debug.Log($"Icon Transform[{i}]: {iconTransform}");

            Image iconImage = iconTransform.GetComponent<Image>();
            Debug.Log($"Icon Image[{i}]: {iconImage}");

            if (iconImage != null)
            {
                iconImage.sprite = items[i].icon;
            }
        }
    }
}
