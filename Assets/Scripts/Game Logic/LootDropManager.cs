using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropManager : MonoBehaviour
{
    public static LootDropManager Instance;

    public GameObject genericLootItemPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        { 
            Destroy(this);
        }
    }

    void SpawnLootFromLootTable(LootTable lootTable, Vector3 position)
    {
        DroppableItem item = lootTable.GetRandomLootDrop();
        GameObject droppedItem = Instantiate(genericLootItemPrefab, position, Quaternion.identity);

        LootDrop lootDropItem = droppedItem.GetComponent<LootDrop>();
    }

    public void RollLootTableChance(LootTable lootTable, float chanceToDropFromTable, Vector3 position)
    {
        float rollForLootTable = Random.Range(0f, 1f);

        if (rollForLootTable <= chanceToDropFromTable)
            SpawnLootFromLootTable(lootTable, position);
    }
}
