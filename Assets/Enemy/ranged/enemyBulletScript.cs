using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;
    public float lifetime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Galaw bala
        rb.velocity = transform.right * speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Despawn yung bala after lifetime
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        // Check if enemy tinamaan, pag oo bigyan ng damage
        healthScript player = collision.GetComponent<healthScript>();
        galaw playerMovement = collision.GetComponent<galaw>();
        if (player != null && playerMovement != null)
        {
            playerMovement.knockBackCounter = playerMovement.knockBackDistance;
            if (playerMovement.transform.position.x <= transform.position.x)
                playerMovement.knockBackRight = true;
            else
                playerMovement.knockBackRight = false;

            player.takeDamage(damage);
            Debug.Log("Damaged:" + damage);
        }

        // Despawn bullet pag may tinamaan
        Destroy(gameObject);

    }
}
