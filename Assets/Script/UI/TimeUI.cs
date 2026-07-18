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

    bool isActive = true;
    float remainTime = 0;
    public event Action OnGameOver;

    private void Awake()
    {
        remainTime = maxTime;
    }

    private void Update()
    {
        if (!isActive) return;
        decreaseSpeed += increaseSpeed * Time.deltaTime;
        remainTime -= decreaseSpeed * Time.deltaTime;
        ChangeTimeInfo(remainTime / maxTime);
        if(remainTime < 0)
        {
            isActive = false;
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
