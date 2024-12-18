using UnityEngine;

//This code is attached to components that have a sprite and will that needs to have their layer sorted dynamically during runtim.
//Such as the player, player arrow or weapon sprite.
public class DynamicOrderInLayerAdjustment : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
    }
}
