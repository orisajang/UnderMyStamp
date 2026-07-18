using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public Player currentPlayer { get; private set; }
    [SerializeField] private int maxFeverGage = 5;
    public int Score { get; private set; }
    public int Combo { get; private set; }
    public int FeverGage { get; private set; }

    private int maxCombo;

    bool isFever = false;

    //UI
    [SerializeField] TimeUI timeUI;
    [SerializeField] ComboTextUI comboTextUI;
    [SerializeField] ScoreTextUI scoreTextUI;
    [SerializeField] FeverBarUI feverBarUI;
    [SerializeField] GameResultCanvas gameOverCanvas;
    [SerializeField] BackgroundChanger backgroundChanger;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Start()
    {
        timeUI.OnGameOver += GameOver;
        UpdateUI();
    }
    private void OnEnable()
    {
        feverBarUI.OnFeverEnd += FeverEnd;
    }
    private void OnDisable()
    {
        feverBarUI.OnFeverEnd -= FeverEnd;
    }
    public void FeverStart()
    {
        FeverGage = 0;
        //피버 발생 넣기
        isFever = true;
        feverBarUI.OnFever(maxFeverGage);
        backgroundChanger.FeverStart();
    }
    public void FeverEnd()
    {
        isFever = false;
        backgroundChanger.FeverEnd();
    }
    public void UpdateUI()
    {
        comboTextUI.ChangeText(Combo);
        scoreTextUI.ChangeText(Score);
    }

    public void WrongAnswer()
    {
        //콤보끊고 시간 게이지 감소시켜야함.
        Combo = 0;
        timeUI.DecreaseTime();
        UpdateUI();
    }

    public void CorrectAnswer()
    {
        //피버
        if(!isFever)
        {
            FeverGage += 1;
            float feverRatio = (float)FeverGage / maxFeverGage;
            if (FeverGage >= maxFeverGage)
            {
                //피버 시작
                FeverStart();
            }
            else
            {
                //피버 게이지 계산
                feverBarUI.SetImageRatio(feverRatio);
            }
        }
        //점수는 현재 콤보에 따라 달라지게 해보자
        int jumsu =  CalcEarnScore();
        Score += jumsu;
        Combo++;
        if (maxCombo < Combo) { maxCombo = Combo; }
        //시간도 올라야하는데?
        timeUI.IncreaseTime();
        //UI 갱신
        UpdateUI();
    }
    private int CalcEarnScore()
    {
        //미니게임에서 실제로 이렇게 반환하는듯? 
        int jumsu = 0;
        if(Combo < 30)
        {
            jumsu = 250;
        }
        else if(Combo < 60)
        {
            jumsu = 400;
        }
        else 
        {
            jumsu = 600;
        }
        if(isFever)
        {
            jumsu *= 2;
        }
        return jumsu;
    }

    public void GameOver()
    {
        //게임 오버처리
        gameOverCanvas.SetResultInfo(Score, maxCombo);
        gameOverCanvas.gameObject.SetActive(true);
    }

}
