using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;

    private void Start() 
    {
        int bestScore = PlayerPrefs.GetInt("bestScore");
        int recordScore = PlayerPrefs.GetInt("recordScore");

        if(bestScore > recordScore)
        {
            recordScore = bestScore;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = recordScore.ToString();
        }
        else
        {
            recordText.text = recordScore.ToString();
        }
    }
    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void BackMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
