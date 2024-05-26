using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void score()
    {
        scoreText.text = "Kills: " + gameData.score.ToString();
    }
}
