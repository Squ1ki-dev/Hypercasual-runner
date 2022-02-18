using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AudioSource btnSfx;

    private void Start() => pausePanel.SetActive(false);

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        btnSfx.Play();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        btnSfx.Play();
    }

    public void BackMenu(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
