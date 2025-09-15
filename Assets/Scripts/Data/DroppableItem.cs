using UnityEngine;

[System.Serializable]
public class DroppableItem
{
    public Item itemData;
    public int amount = 1;
    [Range(0, 1)]
    public float dropRate = 0;
}
