using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    private void Start() => pausePanel.SetActive(false);

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackMenu(int sceneIndex) => SceneManager.LoadScene(sceneIndex);
}
