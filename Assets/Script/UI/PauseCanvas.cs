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
    }
    private void Exit()
    {
        //타이틀 화면으로 나가야할듯
    }

}
