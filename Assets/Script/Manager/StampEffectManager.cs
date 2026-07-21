using DG.Tweening;
using System.Collections;
using UnityEngine;

public class StampEffectManager : MonoBehaviour
{
    //스탬프
    [SerializeField] float delayTime = 0.2f;
    WaitForSeconds delay;
    Coroutine showStampCor;

    Player currentPlayer;

    private void Awake()
    {
        delay = new WaitForSeconds(delayTime);
    }

    private void Start()
    {
        currentPlayer = GameManager.Instance.currentPlayer;
    }

    public void ShowStampEffect()
    {
        if (showStampCor != null)
        {
            StopCoroutine(showStampCor);
            showStampCor = null;
        }
        showStampCor = StartCoroutine(ShowStampEffectCor());

        //화면 흔들림 1회 추가
        float duration = 0.15f;
        float strength = 0.2f;
        Camera.main.DOComplete();
        Camera.main.DOShakePosition(duration, strength);
    }
    IEnumerator ShowStampEffectCor()
    {
        currentPlayer.ShowStampEffect();
        yield return delay;
        currentPlayer.StopStampEffect();
        showStampCor = null;
    }
}
