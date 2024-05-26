using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public radioScript radioScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(loadAsynch());
        }
    }

    IEnumerator loadAsynch()
    {
        if (radioScript.hasRadio)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync("Menu");

            loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                slider.value = progress;

                yield return null;
            }
        }
    }

}
