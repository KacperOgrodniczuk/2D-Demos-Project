using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    float lifeTime = 10f;

    public int damage = 5;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        spriteRenderer = GetComponent<SpriteRenderer>();
        DynamicOrderInLayerManager.Instance.Register(spriteRenderer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.GetComponent<IDamageable>()?.TakeDamage(damage);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DynamicOrderInLayerManager.Instance.Unregister(spriteRenderer);
    }
}
