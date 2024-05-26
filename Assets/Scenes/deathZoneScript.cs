using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZoneScript : MonoBehaviour
{
    public healthScript player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.takeDamage(6);
        }

        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision);
        }
    }
}
