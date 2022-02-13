using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private int sliderValue;
    private float loadingTime;
    [SerializeField] private int sceneIndex;    
    [SerializeField] private Slider loadingSlider;

    void Update()
    {
        NextScene();
    }

    void NextScene()
    {
        loadingSlider.value = sliderValue;
        loadingTime += 20 * Time.deltaTime;

        if(loadingTime >= 1)
        {
            sliderValue += 7;
            loadingTime = 0;
        }
        if(loadingSlider.value >= 100)
            SceneManager.LoadScene(sceneIndex);
    }
}
