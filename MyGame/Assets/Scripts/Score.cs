using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI CoinCountText;
    public int coinCount = 0;
    
    public void UpdateScore()
    {
        coinCount++;
        CoinCountText.text = "Score: " + coinCount;
    }
}
