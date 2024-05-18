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
    public float spearRange = 0.5f;
    public int spearDamage = 50;

    public LineRenderer spearRaycast;
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

        /*if (Input.GetButton("Fire2"))
            StartCoroutine(Tusok(1f));*/
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

    /*IEnumerator Tusok(float waitTime)
    {
        // Cooldown
        if (Time.time - lastShot < attackCooldown)
            yield break;
        lastShot = Time.time;
        RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, firePoint.right, spearRange);

        if (hitinfo)
        {
            enemyScript enemy = hitinfo.transform.GetComponent<enemyScript>();
            if (enemy != null)
            {
                Debug.Log("natusok");
                enemy.takeDamage(spearDamage);
            }

            spearRaycast.SetPosition(0, firePoint.position);
            spearRaycast.SetPosition(1, hitinfo.point);
        }

        spearRaycast.enabled = true;
        yield return new WaitForSeconds(waitTime);
        spearRaycast.enabled = false;
    }*/
}
