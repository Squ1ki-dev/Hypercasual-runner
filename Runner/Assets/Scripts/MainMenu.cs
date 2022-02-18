using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private AudioSource sfxAudio;

    private void Start() 
    {
        Time.timeScale = 1;
        int coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        menuPanel.SetActive(false);
        sfxAudio.Play();
    }

    public void HideSettings()
    {
        settingsPanel.SetActive(false);
        menuPanel.SetActive(true);
        sfxAudio.Play();
    }

    public void PlayGame(int sceneIndex)
    {
        sfxAudio.Play();
        SceneManager.LoadScene(sceneIndex);
    }
    public void Exit() => Application.Quit();
}