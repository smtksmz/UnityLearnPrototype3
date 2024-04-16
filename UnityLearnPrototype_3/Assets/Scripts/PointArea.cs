using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointArea : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    public static int point = 0;
    private int bestScore = 0;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScore();
    }

    void Update()
    {
        _text.text = point.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            point++;
            if (point > bestScore)
            {
                bestScore = point;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            UpdateBestScore();
        }
    }
    private void UpdateBestScore()
    {
        if (_bestScoreText != null)
        {
            _bestScoreText.text = bestScore.ToString();
        }
    }
}
