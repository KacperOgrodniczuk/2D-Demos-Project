using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LootDrop : MonoBehaviour
{
    public Item itemData;

    public int amount;

    private SpriteRenderer spriteRenderer;

    IObjectPool<GameObject> itemPool;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItemData(DroppableItem droppableItem)
    {
        itemData = droppableItem.itemData;
        amount = droppableItem.amount;

        spriteRenderer.sprite = droppableItem.itemData.icon;

        Debug.Log("item data set on new loot");
    }

    public void SetItemObjectPool(IObjectPool<GameObject> pool)
    { 
        itemPool = pool;
    }

    public void ReturnToPool(GameObject item)
    {
        itemPool.Release(item);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // No need to check for tag since collisions are limited in the phsyics collision matrix.
        EventManager.OnItemPickup?.Invoke(itemData, amount);

        Destroy(gameObject);
    }
}