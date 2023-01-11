using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageAndKnockBack : MonoBehaviour
{
    [SerializeField] private float _knockTime = 1f;
    [SerializeField] private float _damage;
    [SerializeField] private HealthController _healthController;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerController player = col.gameObject.GetComponent<PlayerController>();

            if (player != null && player.CurrentState != PlayerState.DAMAGE)
            {
                player.SetInput(false);
                player.SetState(PlayerState.DAMAGE);
                _healthController.TakeDamage(_damage);
                ApplyKnockback(col, player);
            }
        }
    }

    private void ApplyKnockback(Collider2D col,  PlayerController player)
    {
        Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            if (player.Direction == Vector2.right)
            {
                player.SetVelocity(Vector2.left);
            }
            else if (player.Direction == Vector2.left)
            {
                player.SetVelocity(Vector2.right);
            }
            else if (player.Direction == Vector2.down)
            {
                player.SetVelocity(Vector2.up);
            }
            else if (player.Direction == Vector2.up)
            {
                player.SetVelocity(Vector2.down);
            }
            
            StartCoroutine(KnockbackCor(playerRb, player));
        }
    }
    
    private IEnumerator KnockbackCor(Rigidbody2D playerRb, PlayerController player)
    {
        SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
        
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(_knockTime);
        
        playerRb.velocity = Vector2.zero;
        player.SetState(PlayerState.WALK);
        player.SetInput(true);
        playerSprite.color = Color.white;
    }
}
