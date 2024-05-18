using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golemScript : enemyScript
{
    public GameObject player;
    public bool facingRight = true;

    public detectionScript detectionScript;

    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("attack"))
            anim.SetBool("isWalking", detectionScript.detected);
        if (detectionScript.detected)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (direction.x > 0 && !facingRight)
                flip();
            else if (direction.x < 0 && facingRight)
                flip();

            //anim.SetBool("isWalking", true);
            Debug.Log(direction.x);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        if (!detectionScript.detected)
        {
            anim.SetBool("isWalking", false);
        }
    }

    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, -180f, 0f);
    }
}


