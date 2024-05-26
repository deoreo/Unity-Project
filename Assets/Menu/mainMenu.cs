using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public AudioClip buttonClick;

    public void playGame()
    {
        StartCoroutine(loadAsynch());
        gameData.health = 5; 
        gameData.score = 0;
        playSound(buttonClick);
    }

    public void exitGame()
    {
        Application.Quit();
        playSound(buttonClick);
    }

    IEnumerator loadAsynch()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            slider.value = progress;

            yield return null;
        }
    }

    public void playSound(AudioClip clip)
    {
        AudioSource aud = gameObject.AddComponent<AudioSource>();
        aud.clip = clip;
        aud.Play();
        Destroy(aud, clip.length);
    }
}
