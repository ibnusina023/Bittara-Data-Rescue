using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem dust;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator animator;
    public bool isDead = false;

    private bool isFacingRight = true;

    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        // Ambil input di Update
        moveInput = Input.GetAxis("Horizontal");

        animator.SetFloat("RobotSpeed", Mathf.Abs(moveInput));

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            AudioManager.Instance.PlaySFX("Jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            CreateDust();
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        // Ubah velocity hanya di FixedUpdate
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        CreateDust();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void CreateDust()
    {
        dust.Play();
    }
}
