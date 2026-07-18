using TMPro;
using UnityEngine;

public class GameResultCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI maxScoreText;
    [SerializeField] TextMeshProUGUI maxComboText;

    public void SetResultInfo(int score, int maxCombo)
    {
        maxScoreText.text = score.ToString();
        maxComboText.text = maxCombo.ToString();
    }
}
