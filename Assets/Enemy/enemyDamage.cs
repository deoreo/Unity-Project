using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float attackCooldown;
    public int damage;

    public float range;
    public float colliderDistance;

    public healthScript playerHealth;
    public galaw playerMovement;

    public Collider2D enemyCollider;
    public LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;

    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (playerDetected())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //golemScript.canMove = false;
                cooldownTimer = 0;

                anim.SetBool("isWalking", false);
                anim.SetTrigger("attack");

                playerMovement.knockBackCounter = playerMovement.knockBackDistance;
                if (playerMovement.transform.position.x <= transform.position.x)
                    playerMovement.knockBackRight = true;
                else
                    playerMovement.knockBackRight = false;
                
                playerHealth.takeDamage(damage);
            }
        }
       
    }


    private bool playerDetected()
    {
        if (enemyCollider != null)
        {
            RaycastHit2D hit =
            Physics2D.BoxCast(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

            return hit.collider != null;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(enemyCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(enemyCollider.bounds.size.x * range, enemyCollider.bounds.size.y, enemyCollider.bounds.size.z));
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.knockBackCounter = playerMovement.knockBackDistance;
            if (playerMovement.transform.position.x <= transform.position.x)
                playerMovement.knockBackRight = true;
            else
                playerMovement.knockBackRight = false;

            playerHealth.takeDamage(damage);
        }
    }
}
