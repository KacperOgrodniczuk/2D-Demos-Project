using System.Collections.Generic;
using UnityEngine;

//This code is attached to components that have a sprite and will that needs to have their layer sorted dynamically during runtim.
//Such as the player, player arrow or weapon sprite.
public class DynamicOrderInLayerManager : MonoBehaviour
{
    // Singleton instance
    public static DynamicOrderInLayerManager Instance { get; private set; }

    // List of sprite renderers to manage
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate manager objects
        }
    }

    // Register a sprite renderer for sorting
    public void Register(SpriteRenderer spriteRenderer)
    {
        if (!spriteRenderers.Contains(spriteRenderer))
        {
            spriteRenderers.Add(spriteRenderer);
        }
    }

    // Unregister a sprite renderer
    public void Unregister(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderers.Contains(spriteRenderer))
        {
            spriteRenderers.Remove(spriteRenderer);
        }
    }

    // Update sorting order every frame
    private void Update()
    {
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.sortingOrder = Mathf.RoundToInt(renderer.transform.position.y * -100);
        }
    }
}
