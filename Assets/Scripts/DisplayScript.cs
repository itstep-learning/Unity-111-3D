using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        
    }

    void Update()
    {
        scoreText.text = GameState.coins.ToString("D3");
    }
}
