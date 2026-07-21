using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    //UI
    [SerializeField] Image timerBarImage;

    //로직 (추후 분리 필요하면 분리하자)
    [SerializeField] float maxTime = 10f;
    [SerializeField] float plusTime = 0.5f;
    [SerializeField] float baseDecreaseSpeed = 1f;
    [SerializeField] float increaseSpeed = 0.2f;

    float wrongRatio = 1.5f;
    float remainTime = 0;
    float curDecreaseSpeed;
    public event Action OnGameOver;
    bool isGameOver = false;
    bool isFever = false;
    bool isPause = true; 

    private void Awake()
    {
        Init(false);
    }
    public void ChangeTimeInfo(float ratio)
    {
        timerBarImage.fillAmount = ratio;
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
    public void PauseTime()
    {
        isPause = true;
    }
    public void PauseCancel()
    {
        isPause = false;
    }
    public void Init(bool pauseAble)
    {
        isPause = pauseAble; //초기화할때 멈춰있어야하는지 체크
        isGameOver = false;
        isFever = false;
        remainTime = maxTime;
        curDecreaseSpeed = baseDecreaseSpeed;
        ChangeTimeInfo(remainTime / maxTime);
    }
    private void Update()
    {
        if (isGameOver || isFever || isPause) return;
        curDecreaseSpeed += increaseSpeed * Time.deltaTime;
        remainTime -= curDecreaseSpeed * Time.deltaTime;
        ChangeTimeInfo(remainTime / maxTime);
        if(remainTime < 0)
        {
            isGameOver = true;
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
        remainTime -= (plusTime * wrongRatio);
        if(remainTime < 0)
        {
            remainTime = 0;
        }
    }

}
