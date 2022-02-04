using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = ((int)(player.position.z / 2)).ToString();
    }
}
