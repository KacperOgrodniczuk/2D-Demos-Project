using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    float lifeTime = 10f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        spriteRenderer = GetComponent<SpriteRenderer>();
        DynamicOrderInLayerManager.Instance.Register(spriteRenderer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DynamicOrderInLayerManager.Instance.Unregister(spriteRenderer);
    }
}
