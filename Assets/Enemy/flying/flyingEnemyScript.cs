using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemyScript : MonoBehaviour
{
    public GameObject player;
    public bool facingRight = true;

    public enemyScript enemyScript;
    public detectionScript detectionScript;
    public enemyDamage enemyDamage;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionScript.detected)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (direction.x > 0 && !facingRight)
                flip();
            else if (direction.x < 0 && facingRight)
                flip();

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyScript.moveSpeed * Time.deltaTime);
        }

        
    }

    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, -180f, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            enemyScript.takeDamage(100);
    }
}
