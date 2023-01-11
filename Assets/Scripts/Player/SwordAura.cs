using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwordAura : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _swordAuraRb;
    [SerializeField] private float _speed = 5f;
    
    public void AddVelocity(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            _swordAuraRb.velocity = Vector2.up * _speed;
        }
        else if (direction == Vector2.down)
        {
            _swordAuraRb.velocity = Vector2.down * _speed ;
            transform.Rotate(0f, 0f, 180f);
        }
        else if (direction == Vector2.right)
        {
            _swordAuraRb.velocity = Vector2.right * _speed;
            transform.Rotate(0f, 0f, -90f);
        }
        else if (direction == Vector2.left)
        {
            _swordAuraRb.velocity = Vector2.left * _speed;
            transform.Rotate(0f, 0f, 90f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block") || col.CompareTag("Door") || 
            col.CompareTag("Walls") || col.CompareTag("SwitchTrigger") ||
            col.CompareTag("TriggerWall"))
        {
            Destroy(gameObject);
        }
    }
}
