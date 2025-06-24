using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score = 0;

    void Start()
    {
        GameObject scoreTextObject = GameObject.Find("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            if (scoreText != null)
            {
                scoreText.text = "0";
            }
            else
            {
                Debug.LogError("TextMeshProUGUIコンポーネントが見つかりませんでした。");
            }
        }
        else
        {
            Debug.LogError("ScoreTextオブジェクトが見つかりませんでした。");
        }
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("スコアが加算されました。現在のスコア: " + score);
    }
}