using UnityEngine;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] Button continueButton;
    [SerializeField] Button TryAgainButton;
    [SerializeField] Button ExitButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(Continue);
        TryAgainButton.onClick.AddListener(TryAgain);
        ExitButton.onClick.AddListener(Exit);
    }
    private void OnDestroy()
    {
        continueButton.onClick.RemoveAllListeners();
        TryAgainButton.onClick.RemoveAllListeners();
        ExitButton.onClick.RemoveAllListeners();
    }
    private void Continue()
    {
        GameManager.Instance.PauseCancelGame();
        this.gameObject.SetActive(false);
    }
    private void TryAgain()
    {
        //다시 시작.
        GameManager.Instance.RestartGame();
        this.gameObject.SetActive(false);
    }
    private void Exit()
    {
        Application.Quit();
    }

}
