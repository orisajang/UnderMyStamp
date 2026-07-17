using TMPro;
using UnityEngine;

public class ComboTextUI : MonoBehaviour
{
    TextMeshProUGUI comboText;

    private void Awake()
    {
        comboText = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(int amount)
    {
        comboText.text = amount.ToString();
    }
}
