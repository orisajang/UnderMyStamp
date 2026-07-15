using UnityEngine;
using UnityEngine.UI;

public class ChangeStampUI : MonoBehaviour
{
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickChangeStampButton);
    }
    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void ClickChangeStampButton()
    {
        GameManager.Instance.currentPlayer.RequestChangeStamp();
    }
}
