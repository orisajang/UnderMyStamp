using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    //UI
    [SerializeField] Image timerBarImage;

    public void ChangeTimeInfo(float ratio)
    {
        timerBarImage.fillAmount = ratio;
    }
    //로직 (추후 분리 필요하면 분리하자)
    [SerializeField] float maxTime = 10f;
    [SerializeField] float plusTime = 0.5f;
    [SerializeField] float decreaseSpeed = 1f;
    [SerializeField] float increaseSpeed = 0.2f;

    bool isGameOver = true;
    float remainTime = 0;
    public event Action OnGameOver;

    bool isFever = false;
    bool isPause = false;

    private void Awake()
    {
        remainTime = maxTime;
    }
    public void FeverStart()
    {
        //피버 상태로 인한 타이머 정지, 최대치로 시간 증가
        isFever = true;
        remainTime = maxTime;
        ChangeTimeInfo(remainTime / maxTime);
    }
    public void FeverEnd()
    {
        isFever = false;
    }
    public void PuaseTime()
    {
        isPause = true;
    }
    public void PauseCancel()
    {
        isPause = false;
    }
    private void Update()
    {
        if (!isGameOver || isFever || isPause) return;
        decreaseSpeed += increaseSpeed * Time.deltaTime;
        remainTime -= decreaseSpeed * Time.deltaTime;
        ChangeTimeInfo(remainTime / maxTime);
        if(remainTime < 0)
        {
            isGameOver = false;
            OnGameOver?.Invoke();
        }

        //만약 remainTime가 0이하라면? 게임오버 되어야함
    }
    public void IncreaseTime()
    {
        remainTime += plusTime;
        if (remainTime > maxTime)
        {
            remainTime = maxTime;
        }
    }
    public void DecreaseTime()
    {
        remainTime -= plusTime;
        if(remainTime < 0)
        {
            remainTime = 0;
        }
    }

}
