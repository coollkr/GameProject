using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script updates the inventory UI based on the item list the player has  
 */
public class ItemDisplay : MonoBehaviour
{
    public InventoryManager manager;         // access the item list
    private List<UsableItem> items;          // save the items
    private List<Transform> itemDisplay;     // list of the item pictures in the UI
    public Sprite yinyang;                   // the default picture

    public void Start()
    {
        itemDisplay = new List<Transform>();
        
        foreach(Transform child in transform)
        {
            itemDisplay.Add(child);      // add all pictures in the UI to the list 
        }

    }
    public void Update()
    {
        items = manager.getItems();     // update the item list

        for (int i = 0; i < 6; i++)     // loop six time for the six pictures  
        {

            if (i < items.Count)
            {
                Transform itemNameTransform = itemDisplay[i].transform.Find("ItemName");  // get the iten name
                TMPro.TextMeshProUGUI itemNameText = itemNameTransform.GetComponent<TMPro.TextMeshProUGUI>(); // get the item name display in UI

                if (itemNameText != null)
                {
                    itemNameText.text = items[i].itemName;   // change the UI text 
                }

                Transform iconTransform = itemDisplay[i].transform.Find("Icon"); // get the item's icon

                Image iconImage = iconTransform.GetComponent<Image>();        // get the item picture in UI


                if (iconImage != null)
                {
                    iconImage.sprite = items[i].icon; // replace the picture by the icon
                }
            }
            else
            {
                // For the rest of the pictures in UI, display the default image
                Transform itemNameTransform = itemDisplay[i].transform.Find("ItemName");
                TMPro.TextMeshProUGUI itemNameText = itemNameTransform.GetComponent<TMPro.TextMeshProUGUI>();
                if (itemNameText != null)
                {
                    itemNameText.text = ""; // make the item name empty
                }

                Transform iconTransform = itemDisplay[i].transform.Find("Icon");
                Image iconImage = iconTransform.GetComponent<Image>();
                if(iconImage != null)
                {
                    iconImage.sprite = yinyang;
                }

            }
        }
    }
}
