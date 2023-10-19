using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int playerscore =0;
    
    void Update()
    {
        
        scoreText.text = "Score: " + playerscore.ToString();
    }
}
