using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        if (health < 0)
        {
            Debug.Log("dead");
            Destroy(gameObject);
        }

        health -= damage;
        Debug.Log("ouch");  
    }


}
