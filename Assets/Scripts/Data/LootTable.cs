using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootTable", menuName = "Drops/Loot Table")]
public class LootTable : ScriptableObject
{
    public List<DroppableItem> possibleDrops;

    public DroppableItem GetRandomLootDrop()
    {
        if (possibleDrops == null || possibleDrops.Count == 0)
        {
            Debug.Log("No possible drops in loot table");
            return null;
        }

        float totalWeight = 0f;

        foreach (var item in possibleDrops)
        {
            totalWeight += item.dropRate;
        }

        float randomValue = Random.Range(0f, totalWeight);

        float currentWeight = 0f;
        foreach (var item in possibleDrops)
        { 
            currentWeight += item.dropRate;
            if (randomValue <= currentWeight)
            {
                return item;
            }
        }

        return null;
    }
}
