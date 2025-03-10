using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    DetectionZone detectionZone;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        detectionZone = GetComponent<DetectionZone>();
    }

    public void OnWalk()
    {
        animator.SetBool("isWalking", true);
    }

    public void OnWalkStop()
    {
        animator.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {
        if (detectionZone.detactedObjs != null)
        {
            Vector2 direction = (detectionZone.detactedObjs.transform.position - transform.position);
            if (direction.magnitude <= detectionZone.viewRadius)
            {
                rb.AddForce(direction.normalized * speed);
                if(direction.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                if(direction.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                OnWalk();
            }
            else
            {
                OnWalkStop();
            }
        }
    }


}

