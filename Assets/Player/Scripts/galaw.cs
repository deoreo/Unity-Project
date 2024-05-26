using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class galaw : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed;
    public float jumpForce;
    public float knockback;
    bool isGrounded;
    public bool facingRight = true;
    public AudioClip jumpSFX, landSFX;

    public float knockBackForce;
    public float knockBackCounter;
    public float knockBackDistance;

    public bool knockBackRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        if (knockBackCounter <= 0)
            rb.velocity = new Vector2(hAxis * moveSpeed, rb.velocity.y);
        else
        {
            if (knockBackRight == true)
                rb.velocity = new Vector2(-knockBackForce * 2, knockBackForce/2);
            else
                rb.velocity = new Vector2(knockBackForce * 2, knockBackForce/2);

            knockBackCounter -= Time.deltaTime;
        }

        // Palingunin character
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
            flip();
        else if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
            flip();

        anim.SetBool("isWalking", hAxis != 0);
        anim.SetBool("isFalling", rb.velocity.y < 0);

        // Check if nasa sahig gamit maliit na collider sa paa
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
         
            anim.SetTrigger("jump");
            playSound(jumpSFX);
        }
    }

    public void playSound(AudioClip clip)
    {
        AudioSource aud = gameObject.AddComponent<AudioSource>();
        aud.clip = clip;
        aud.Play();
        Destroy(aud, clip.length);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playSound(landSFX);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            rb.AddForce(new Vector2(knockback, rb.velocity.y), ForceMode2D.Impulse);

            Debug.Log("ouch");
        }
    }

    // Flip character para makalingon
    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, -180f, 0f);
    }

}
