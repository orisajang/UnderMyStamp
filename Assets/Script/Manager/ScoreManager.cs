using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; }
    public int Combo { get; private set; }
    public int maxCombo { get; private set; }
    private int correctCount = 0;

    public Action<int> OnScoreChange;
    public Action<int> OnComboChange;

    bool isFever = false;

    public void Init()
    {
        Score = 0;
        Combo = 0;
        maxCombo = 0;
        UpdateUI();
    }

    public void SetFeverState(bool state)
    {
        isFever = state;
    }

    public void IncrementScoreAndCombo()
    {
        correctCount++;
        if(correctCount % 3 == 0)
        {
            PaperMountainSpawner.Instance.GetPaperByPool();
        }
        int jumsu = CalcEarnScore();
        Score += jumsu;
        Combo++;
        if (maxCombo < Combo) { maxCombo = Combo; }
        //점수 표시
        EarnedTextManager.Instance.ShowText(jumsu.ToString());
        UpdateUI();
    }

    public void SetComboZero()
    {
        Combo = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        OnScoreChange?.Invoke(Score);
        OnComboChange?.Invoke(Combo);
    }
    private int CalcEarnScore()
    {
        //미니게임에서 실제로 이렇게 반환하는듯? 
        int jumsu = 0;
        if (Combo < 30)
        {
            jumsu = 250;
        }
        else if (Combo < 60)
        {
            jumsu = 400;
        }
        else
        {
            jumsu = 600;
        }
        if (isFever)
        {
            jumsu *= 2;
        }
        return jumsu;
    }
}
