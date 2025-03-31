
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public InputAction playMovement;
    public float moveSpeed = 5f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    Vector2 moveDirection = Vector2.zero;
    

    private void OnEnable()
    {
        playMovement.Enable();
    }
      private void OnDisable()
    {
        playMovement.Disable();
    }

    void Update()
    {
        moveDirection = playMovement.ReadValue<Vector2>();
        if(moveDirection == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if(moveDirection.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            if(moveDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }



    

}
