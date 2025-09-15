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
            return null;
        }

        float totalWeight = 0f;

        foreach (var item in possibleDrops)
        {
            totalWeight += item.dropRate;
        }

        float randomValue = Random.Range(0f, totalWeight);

        foreach (var item in possibleDrops)
        { 
            randomValue -= item.dropRate;
            if (randomValue <= 0)
            {
                return item;
            }
        }

        return null;
    }
}
