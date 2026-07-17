using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] Image timerBarImage;

    public void ChangeTimeInfo(float ratio)
    {
        timerBarImage.fillAmount = ratio;
    }
    public void IncreaseTime()
    {
        remainTime += plusTime;
        if(remainTime > maxTime)
        {
            remainTime = maxTime;
        }
    }
    //로직 (추후 분리 필요하면 분리하자)
    [SerializeField] float maxTime = 10f;
    [SerializeField] float remainTime = 10f;
    [SerializeField] float plusTime = 0.5f;
    [SerializeField] float decreaseSpeed = 1f;
    [SerializeField] float increaseSpeed = 0.2f;

    private void Update()
    {
        decreaseSpeed += increaseSpeed * Time.deltaTime;
        remainTime -= decreaseSpeed * Time.deltaTime;
        ChangeTimeInfo(remainTime / maxTime);

        //만약 remainTime가 0이하라면? 게임오버 되어야함
    }
}
