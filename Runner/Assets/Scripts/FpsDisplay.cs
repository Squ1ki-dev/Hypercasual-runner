using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;

    [SerializeField] private float pollingTime = 3f;
    private float time;
    private int fpsCount;
    
    void Update()
    {
        ShowFps();
    }

    void ShowFps()
    {
        time += Time.deltaTime;

        fpsCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(fpsCount / time);
            fpsText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            fpsCount = 0;
        }
    }
}
