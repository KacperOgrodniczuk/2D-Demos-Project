using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public Item itemData;

    public int amount;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItemData(DroppableItem droppableItem)
    {
        itemData = droppableItem.itemData;
        amount = droppableItem.amount;

        spriteRenderer.sprite = droppableItem.itemData.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // No need to check for tag since collisions are limited in the phsyics collision matrix.
        EventManager.OnItemPickup?.Invoke(itemData, amount);

        Destroy(gameObject);
    }
}
