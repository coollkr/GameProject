using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Create New Item")]
public class UsableItem : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;

}
