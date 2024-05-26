using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    Rigidbody2D rb;
    public Animator anim;
    public AudioClip hurtSFX;

    public Behaviour[] components;

    public scoreScript scoreScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float time = Time.deltaTime;
        if (!components[0].enabled)
        {
            Destroy(gameObject, 1.5f);
        }
    }

    public void takeDamage(int damage)
    {
        if (health <= 0)
        {
            anim.SetTrigger("die");

            gameData.score += 1;

            foreach  (Behaviour component in components)
                component.enabled = false;
        }

        health -= damage;
        playSound(hurtSFX);

        scoreScript.score();
    }

    public void playSound(AudioClip clip)
    {
        AudioSource aud = gameObject.AddComponent<AudioSource>();
        aud.clip = clip;
        aud.Play();
        Destroy(aud, clip.length);
    }
}
