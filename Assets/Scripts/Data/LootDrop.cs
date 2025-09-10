using UnityEngine;

public class LootDrop : MonoBehaviour {

    [Tooltip("The data of the item this physical object represents")]
    public Item itemData;

    [Tooltip("The amount of the item to add to the inventory upon collection")]
    public int amount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.OnItemPickup?.Invoke(itemData, amount);

            Destroy(gameObject);
        }
    }
}
