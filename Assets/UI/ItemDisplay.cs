using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public InventoryManager manager;
    private List<UsableItem> items;
    private List<Transform> itemDisplay;
    public Sprite yinyang;

    public void Start()
    {
        itemDisplay = new List<Transform>();
        

        foreach(Transform child in transform)
        {
            itemDisplay.Add(child);
        }

    }
    public void Update()
    {
        items = manager.getItems();

        for (int i = 0; i < 6; i++)
        {

            if (i < items.Count)
            {
                Transform itemNameTransform = itemDisplay[i].transform.Find("ItemName");
                TMPro.TextMeshProUGUI itemNameText = itemNameTransform.GetComponent<TMPro.TextMeshProUGUI>();

                if (itemNameText != null)
                {
                    itemNameText.text = items[i].itemName;
                }

                Transform iconTransform = itemDisplay[i].transform.Find("Icon");


                Image iconImage = iconTransform.GetComponent<Image>();


                if (iconImage != null)
                {
                    iconImage.sprite = items[i].icon;
                }
            }
            else
            {
                Transform itemNameTransform = itemDisplay[i].transform.Find("ItemName");
                TMPro.TextMeshProUGUI itemNameText = itemNameTransform.GetComponent<TMPro.TextMeshProUGUI>();
                if (itemNameText != null)
                {
                    itemNameText.text = "";
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
