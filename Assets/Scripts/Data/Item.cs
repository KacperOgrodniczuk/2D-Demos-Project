using UnityEngine;

// Base class for all item data.

public class Item : ScriptableObject
{
    [Tooltip("Unique ID of the item. Used for a lookup in an inventory system.")]
    public string itemID;

    public string itemName;
    public Sprite icon;
}
