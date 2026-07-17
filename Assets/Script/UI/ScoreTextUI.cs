using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(int amount)
    {
        scoreText.text = amount.ToString();
    }
}
