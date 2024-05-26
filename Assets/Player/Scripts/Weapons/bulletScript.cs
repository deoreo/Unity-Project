using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;
    public float lifetime = 1f;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Galaw bala
        rb.velocity = transform.right * speed;
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
        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            enemy.anim.SetTrigger("hurt");
            Debug.Log("Damaged:" + damage);
        }
            
        // Despawn bullet pag may tinamaan
        Destroy(gameObject);

    }
}
