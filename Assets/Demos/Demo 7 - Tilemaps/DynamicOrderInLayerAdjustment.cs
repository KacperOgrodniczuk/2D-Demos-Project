using System.Collections.Generic;
using UnityEngine;

public class DynamicOrderInLayerAdjustment : MonoBehaviour
{
    public List<SpriteRenderer> PlayerSprites;

    // Update is called once per frame
    void Update()
    {
        //It's a list so that I can also update player arrow and book sprites based on player position.
        foreach (SpriteRenderer spriteRenderer in PlayerSprites)
        {
            spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
        }
    }
}
