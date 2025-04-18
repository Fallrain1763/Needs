
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Player player;
    
    public Sprite chestOpen;
    public GameObject crown;

    public static bool isOrcDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if(moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if(moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }
            if(moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
        }
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }
    void OnDie()
    {
        animator.SetTrigger("isDead");
        StartCoroutine(LoadMenuScene());
    }

    IEnumerator LoadMenuScene(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }

    void OnDamage()
    {
        player.TakeDamage(1);
    }

    #region Animation method
    private void OnDestroy()
    {
        gameObject.SetActive(false);     
    }
    #endregion

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "wood")
        {
            Destroy(collider.gameObject);
            player.woodCount += 1;
        }

         if (collider.gameObject.tag == "Chest")
         {
            if(Dialogue.isKey)
            {
                collider.GetComponent<SpriteRenderer>().sprite = chestOpen;
                crown.SetActive(true);
                Dialogue.isChestOpen = true;
            }
         }
    }


}
