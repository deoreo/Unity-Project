using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    Animator anim;

    float lastShot;
    public float attackCooldown = 1.5f;

    public AudioClip LaserSFX;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        // Cooldown
        if (Time.time - lastShot < attackCooldown)
            return;
        lastShot = Time.time;
        anim.SetTrigger("fire");
        gameObject.GetComponent<galaw>().playSound(LaserSFX);

        // Spawn bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
