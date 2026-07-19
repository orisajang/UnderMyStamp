using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] PauseCanvas pauseCanvas;
    Button pauseButton;

    private void Awake()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(ButtonClick);
    }
    private void OnDestroy()
    {
        pauseButton.onClick.RemoveAllListeners();
    }
    private void ButtonClick()
    {
        GameManager.Instance.PauseGame();
        pauseCanvas.gameObject.SetActive(true);
    }

}
