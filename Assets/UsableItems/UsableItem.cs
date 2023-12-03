using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * This script is to define what an item is and enable creating items in the directory
 * 
 */
[CreateAssetMenu(fileName = "New Item", menuName = "Create New Item")]
public class UsableItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;

}
