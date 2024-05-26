using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public GameObject loseScreen;

    public healthScript player;

    public AudioClip buttonClick;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(objs[0]);
        }
    }

    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
        playSound(buttonClick);
        gameData.health = 5;
        gameData.score = 0;
    }

    public void menu() 
    {
        SceneManager.LoadScene("Menu");
        playSound(buttonClick);
    }

    public void playSound(AudioClip clip)
    {
        AudioSource aud = gameObject.AddComponent<AudioSource>();
        aud.clip = clip;
        aud.Play();
        Destroy(aud, clip.length);
    }
}
