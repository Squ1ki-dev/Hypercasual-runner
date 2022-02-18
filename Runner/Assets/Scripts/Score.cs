using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] private Transform player;

    private void Update() => scoreText.text = ((int)(player.position.z / 2)).ToString();
}
