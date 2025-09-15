using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootDropper : MonoBehaviour
{
    public List<LootDropTableContainer> possibleLootTables;

    [System.Serializable]
    public class LootDropTableContainer
    { 
        public LootTable lootTable;
        [Tooltip("The chance that this specific loot table will drop an item.")]
        [Range(0, 1)]
        public float lootTableRollChance = 1f;
    }

    public void DropLoot()
    {
        foreach (var lootTableContainer in possibleLootTables)
        {
            LootDropManager.Instance.RollLootTableChance(lootTableContainer.lootTable, lootTableContainer.lootTableRollChance, transform.position);
        }
    }
}
