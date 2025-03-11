using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.AddForce(knockback);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }
}
