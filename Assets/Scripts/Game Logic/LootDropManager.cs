using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Pool;

public class LootDropManager : MonoBehaviour
{
    public static LootDropManager Instance;

    public GameObject genericLootDropPrefab;

    private IObjectPool<GameObject> lootDropPool;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        { 
            Destroy(this);
        }

        lootDropPool = new ObjectPool<GameObject>(CreateLootDrop, OnGetLootDrop, OnReleaseLootDrop, OnDestroyLootDrop);
    }

    void SpawnLootFromLootTable(LootTable lootTable, Vector3 position)
    {
        DroppableItem item = lootTable.GetRandomLootDrop();

        Debug.Log(item);

        GameObject lootDropObject = lootDropPool.Get();

        LootDrop lootDropItem = lootDropObject.GetComponent<LootDrop>();
        Debug.Log("got the loot drop component");

        lootDropItem.SetItemData(item);
        Debug.Log("set item data for loot.");

        lootDropObject.transform.position = position;

        Debug.Log("spawned loot from talbe, hopefully.");
    }

    public void RollLootTableChance(LootTable lootTable, float chanceToDropFromTable, Vector3 position)
    {
        float rollForLootTable = Random.Range(0f, 1f);

        Debug.Log("rool is " + rollForLootTable);
        if (rollForLootTable <= chanceToDropFromTable)
        {
            Debug.Log("succesfully rolled to drop from table.");
            SpawnLootFromLootTable(lootTable, position);
        }
    }

    private GameObject CreateLootDrop()
    {
        GameObject droppedItem = Instantiate(genericLootDropPrefab, Vector3.zero, Quaternion.identity);
        droppedItem.GetComponent<LootDrop>().SetItemObjectPool(lootDropPool);
        return droppedItem;
    }

    private void OnGetLootDrop(GameObject item)
    {
        item.SetActive(true);
    }

    private void OnReleaseLootDrop(GameObject item)
    {
        item.SetActive(false);
    }

    private void OnDestroyLootDrop(GameObject item)
    {
        Destroy(item);
    }
}