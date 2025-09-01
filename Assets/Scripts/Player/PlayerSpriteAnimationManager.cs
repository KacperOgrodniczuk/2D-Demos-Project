using UnityEngine;

public class PlayerSpriteAnimationManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public SpriteRenderer weaponRenderer;
    public SpriteRenderer arrowRenderer;
    Animator animator;

    PlayerMovementManager playerMovement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovementManager>();
        
        DynamicOrderInLayerManager.Instance.Register(spriteRenderer);
        DynamicOrderInLayerManager.Instance.Register(weaponRenderer);
        DynamicOrderInLayerManager.Instance.Register(arrowRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving);

        //Flip the sprite based on the direction we move in
        if (playerMovement.rb2d.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerMovement.rb2d.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDisable()
    {
        DynamicOrderInLayerManager.Instance.Unregister(spriteRenderer);
        DynamicOrderInLayerManager.Instance.Unregister(weaponRenderer);
        DynamicOrderInLayerManager.Instance.Unregister(arrowRenderer);
    }
}
