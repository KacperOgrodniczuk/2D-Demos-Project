using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    float lifeTime = 10f;

    float damage = 1;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        
        DynamicOrderInLayerManager.Instance.Register(spriteRenderer);
    }

    public void Shoot(Vector3 direction, float projectileSpeed, float projectileDamage)
    {
        damage = projectileDamage;

        rigidBody2D.velocity = direction * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<IDamageable>()?.TakeDamage(damage);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        DynamicOrderInLayerManager.Instance.Unregister(spriteRenderer);
    }
}
