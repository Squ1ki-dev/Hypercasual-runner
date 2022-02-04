using System.Collections;
using System.Threading;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    [SerializeField] private int maxRate = 240;
    [SerializeField] private float targetFrameRate = 60.0f;
    private float currentFrameTime;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = maxRate;
        currentFrameTime = Time.realtimeSinceStartup;
        StartCoroutine(WaitForNextFrame());
    }

    private IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            currentFrameTime += 1.0f / targetFrameRate;
            var t = Time.realtimeSinceStartup;
            if (currentFrameTime - Time.realtimeSinceStartup - 0.01f > 0)
                Thread.Sleep((int)((currentFrameTime - Time.realtimeSinceStartup - 0.01f) * 1000));
            while (Time.realtimeSinceStartup < currentFrameTime)
                t = Time.realtimeSinceStartup;
        }
    }
}