using System;
using UnityEngine;

public class Player2DMovementScript : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public LayerMask groundLayerMask;
    public LayerMask wallLayerMask;
    public float wallJumpCooldown;
    public bool isInDialogue;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private float initialGravityScale;
    private float currentWallJumpCooldown;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        initialGravityScale = body.gravityScale;
    }

    private void Update()
    {
        if (isInDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
                SceneManagerScript.Instance.dialogueManagerScript.DisplayNextSentence();
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            FlipCharacterAccordingToWalkingDirection(horizontalInput);

            if (currentWallJumpCooldown > wallJumpCooldown)
            {
                body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

                if (OnWall() && !IsGrounded())
                {
                    body.gravityScale = 1f;
                    body.velocity = Vector2.zero;
                }
                else
                    body.gravityScale = initialGravityScale;

                if (Input.GetKeyDown(KeyCode.Space))
                    Jump();
            }
            else
                currentWallJumpCooldown += Time.deltaTime;

            animator.SetBool("isWalking", horizontalInput != 0);
            animator.SetBool("isGrounded", IsGrounded());
            animator.SetBool("isOnWall", OnWall());
        }
    }

    private void FlipCharacterAccordingToWalkingDirection(float horizontalInput)
    {
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-1, transform.localScale.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            SoundManager.instace.PlaySound(jumpSound);
            animator.SetTrigger("jump");
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        } 
        else if (OnWall() && !IsGrounded())
        {
            SoundManager.instace.PlaySound(jumpSound);
            currentWallJumpCooldown = 0;
            float xOppositeDirection = -Mathf.Sign(transform.localScale.x);
            body.velocity = new Vector2(xOppositeDirection * 1.5f, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector3.down, 0.1f, groundLayerMask);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.05f, wallLayerMask);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return !isInDialogue && IsGrounded() && !OnWall();
    }
}
