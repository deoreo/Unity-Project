using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public AnimationClip death;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Debug.Log(health);
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("dead");
            anim.SetTrigger("dead");
            
        }
    }
}
