using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemy : MonoBehaviour
{
    public GameObject player;
    public bool facingRight = false;

    public enemyScript enemyScript;
    public detectionScript detectionScript;

    public Transform firePoint;
    public GameObject bulletPrefab;

    float lastShot = -99999f;
    public float attackCooldown = 3f;

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
            Shoot();
        }

        Vector2 direction = player.transform.position - transform.position;

        if (direction.x > 0 && facingRight)
            flip();
        else if (direction.x < 0 && !facingRight)
            flip();


    }

    void flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, -180f, 0f);
    }

    void Shoot()
    {
        // Cooldown
        if (Time.time - lastShot < attackCooldown)
            return;
        lastShot = Time.time;

        // Spawn bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
