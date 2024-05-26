using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    public enemyScript boss;
    public GameObject radio;


    private void Update()
    {
        if (boss.health <= 0)
        {
            radio.SetActive(true);
        }
    }
}
