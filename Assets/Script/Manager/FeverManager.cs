using System;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour
{
    public int FeverGage { get; private set; }
    bool isFever = false;
    [field: SerializeField] public int maxFeverGage { get; private set; } = 5;

    public event Action<bool> OnFever;
    public event Action<float> OnFeverRatioChanged;

    //피버 상태일때 시간 체크
    float curTime;
    float maxTime;
    bool isPause;
    public void FeverStart()
    {
        FeverGage = 0;
        //피버 발생 넣기
        isFever = true;
        maxTime = maxFeverGage;
        curTime = 0;
        OnFever?.Invoke(isFever);
    }
    public void FeverEnd()
    {
        isFever = false;
        OnFever?.Invoke(isFever);
    }
    public bool IsFever()
    {
        return isFever;
    }
    public void PauseTime()
    {
        isPause = true;
    }
    public void PauseCancel()
    {
        isPause = false;
    }
    public void IncrementFeverGage()
    {
        //피버
        if (!isFever)
        {
            FeverGage += 1;
            float feverRatio = (float)FeverGage / maxFeverGage;
            OnFeverRatioChanged?.Invoke(feverRatio);
            if (FeverGage >= maxFeverGage)
            {
                //피버 시작
                FeverStart();
            }
        }
    }

    public void Init()
    {
        FeverGage = 0;
        isFever = false;
        isPause = false;
        isFever = false;
        curTime = 0;
        OnFeverRatioChanged?.Invoke(0);
    }
    private void Update()
    {
        if (isFever && !isPause)
        {
            curTime += Time.deltaTime;
            float ratio = 1f - (curTime / maxTime);
            
            if (curTime >= maxTime)
            {
                isFever = false;
                ratio = 0;
                FeverEnd();
            }
            OnFeverRatioChanged?.Invoke(ratio);
        }
    }
}
