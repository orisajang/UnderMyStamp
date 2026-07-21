using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    Button restartButton;

    private void Awake()
    {
        restartButton = GetComponent<Button>();
    }
    private void Start()
    {
        restartButton.onClick.AddListener(GameManager.Instance.RestartGame_GameEnd);
    }
    private void OnDestroy()
    {
        restartButton.onClick.RemoveAllListeners();
    }

}
