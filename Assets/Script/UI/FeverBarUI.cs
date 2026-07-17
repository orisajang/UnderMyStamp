using System;
using UnityEngine;
using UnityEngine.UI;

public class FeverBarUI : MonoBehaviour
{
    [SerializeField] Image barImage;

    bool isFever = false;

    float curTime;
    float maxTime;

    public event Action OnFeverEnd;

    public void SetImageRatio(float ratio)
    {
        barImage.fillAmount = ratio;
    }
    public void OnFever(float max)
    {
        isFever = true;
        maxTime = max;
        curTime = 0;
    }


    private void Update()
    {
        
        if(isFever)
        {
            curTime += Time.deltaTime;
            float ratio = 1f - (curTime / maxTime);
            barImage.fillAmount = ratio;
            //float ratio = (curTime / maxTime);
            if (curTime >= maxTime)
            {
                isFever = false;
                barImage.fillAmount = 0;
                OnFeverEnd?.Invoke();
            }   
        }
    }


}
