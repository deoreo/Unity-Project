using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radioScript : MonoBehaviour
{
    public bool hasRadio;

    public AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasRadio)
        {
            hasRadio = true;
            aud.Play();
            Destroy(gameObject, aud.clip.length);
        } 
    }
}
