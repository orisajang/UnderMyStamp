using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameStartCanvas : MonoBehaviour
{
    //게임 시작 전, 활성화되면 카운트 세고, 스스로 자신을 비활성화 하는 캔버스
    //[SerializeField] int delayTime = 3;
    int startTime = 3;
    int delayTime = 1;
    WaitForSeconds delay;
    [SerializeField] GameObject timerTextParent;
    [SerializeField] TextMeshProUGUI timerText;
    Coroutine startCor;
    int currentTime;

    //텍스트 애니메이션
    [SerializeField] float animDuration = 0.5f;
    [SerializeField] float startScale = 0.3f;
    [SerializeField] float endScale = 1f;


    public event Action OnTimerEnd;

    private void Awake()
    {
        delay = new WaitForSeconds(delayTime);
    }
    void PlayTimerAnimation()
    {
        timerTextParent.transform.localScale = Vector3.one * startScale;

        timerTextParent.transform
            .DOScale(endScale, animDuration)
            .SetEase(Ease.OutBack);
    }
    IEnumerator StartCor()
    {
        while(currentTime > 0)
        {
            yield return delay;
            timerText.text = currentTime.ToString();
            PlayTimerAnimation();
            currentTime--;
        }
        yield return delay;
        timerText.text = "Start!!";
        PlayTimerAnimation();
        yield return delay;
        OnTimerEnd?.Invoke();
        this.gameObject.SetActive(false);
    }
    public void Init()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
        if (startCor != null)
        {
            StopCoroutine(startCor);
            startCor = null;
        }
        startCor = StartCoroutine(StartCor());
    }


    private void OnEnable()
    {
        Init();
    }
    private void OnDisable()
    {
        
    }

}
