using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    private void Start() 
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
    }

    public void PlayGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("вышел");
    }
}
