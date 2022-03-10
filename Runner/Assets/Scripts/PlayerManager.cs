using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameStarted;
    [SerializeField] private GameObject startingText;
    
    void Start()
    {
        Time.timeScale = 1;
        isGameStarted = false;
    }

    
    void Update()
    {
        if(SwipeController.tap && !isGameStarted)
        {
            isGameStarted = true;
            Destroy(startingText);
        }       
    }
}
