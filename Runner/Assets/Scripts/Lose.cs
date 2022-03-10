using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;
    private int bestScore;
    private int recordScore;

    private void Start() 
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        recordScore = PlayerPrefs.GetInt("recordScore");

        if(bestScore > recordScore)
        {
            recordScore = bestScore;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = "BEST SCORE: " + recordScore.ToString();
        }
        else
            recordText.text = "BEST SCORE: " + recordScore.ToString();
    }
    
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void BackMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1;
    }
}
