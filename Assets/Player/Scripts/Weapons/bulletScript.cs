using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 1;
    public float lifetime = 1.5f;
    private float time;
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
        time += Time.deltaTime;
        if (time > 1.5f) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        anim.SetTrigger("hit");

        // Check if enemy tinamaan, pag oo bigyan ng damage
        enemyScript enemy = collision.GetComponent<enemyScript>();
        if (enemy != null)
            enemy.takeDamage(damage);



        // Despawn bullet pag may tinamaan
        Destroy(gameObject);

    }
}
