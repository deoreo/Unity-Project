using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthScript : MonoBehaviour
{
    public int maxHealth;
    public int health;
    
    public healthBarScript healthBar;

    public Animator anim;

    public Behaviour[] components;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //health = maxHealth;
        healthBar.setHealth(gameData.health);
    }
    
    public void takeDamage(int damage)
    {
        gameData.health -= damage;
        if (gameData.health <= 0)
        {
            Debug.Log("dead");
            anim.SetTrigger("dead");

            foreach (Behaviour component in components)
                component.enabled = false;

            StartCoroutine(gameOver());

        }
        healthBar.setHealth(gameData.health);
    }

    IEnumerator gameOver()
    {
        yield return new WaitForSeconds(1.5f);

        gameData.currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene("Game Over");
    }
}
