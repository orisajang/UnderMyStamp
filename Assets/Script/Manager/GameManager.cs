using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //리펙토링 진행. 스코어, 이펙트, 피버
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] FeverManager feverManager;
    [SerializeField] StampEffectManager stampEffectManager;

    [field: SerializeField] public Player currentPlayer { get; private set; }

    //UI
    [SerializeField] TimeUI timeUI;
    [SerializeField] ComboTextUI comboTextUI;
    [SerializeField] ScoreTextUI scoreTextUI;
    [SerializeField] FeverBarUI feverBarUI;
    [SerializeField] GameResultCanvas gameOverCanvas;
    [SerializeField] BackgroundChanger backgroundChanger;
    [SerializeField] GameStartCanvas gameStartCanvas;

    //전부 처리 끝나고 고객이 나가는 위치
    [SerializeField] Transform exitPosition;

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
        InitInfo();
        //timeUI.PauseTime();
    }
    private void OnEnable()
    {
        timeUI.OnGameOver += GameOver;
        gameStartCanvas.OnTimerEnd += GameStart;

        scoreManager.OnScoreChange += scoreTextUI.ChangeText;
        scoreManager.OnComboChange += comboTextUI.ChangeText;
        feverManager.OnFever += FeverCheck;
        feverManager.OnFeverRatioChanged += feverBarUI.SetImageRatio;
    }
    private void OnDisable()
    {
        timeUI.OnGameOver -= GameOver;
        gameStartCanvas.OnTimerEnd -= GameStart;

        scoreManager.OnScoreChange -= scoreTextUI.ChangeText;
        scoreManager.OnComboChange -= comboTextUI.ChangeText;
        feverManager.OnFever -= FeverCheck;
        feverManager.OnFeverRatioChanged -= feverBarUI.SetImageRatio;
    }
    public void GameStart()
    {
        timeUI.Init(false);
        feverManager.Init();
    }
    public void FeverCheck(bool isFever)
    {
        if(isFever)
        {
            FeverStart();
        }
        else
        {
            FeverEnd();
        }
    }
    private void FeverStart()
    {
        backgroundChanger.FeverStart();
        timeUI.FeverStart();
        SoundManager.Instance.PlaySFX(eSoundType.CatSound);
    }
    private void FeverEnd()
    {
        backgroundChanger.FeverEnd();
        timeUI.FeverEnd();
        SoundManager.Instance.PlaySFX(eSoundType.CatSound);
    }

    public bool IsFever()
    {
        return feverManager.IsFever();
    }


    public void ShowStampEffect()
    {
        stampEffectManager.ShowStampEffect();
    }

    public void CorrectAnswer(Customer customer)
    {
        //고객의 상태 변경
        customer.SetSprite(eCustomerState.Success);
        customer.transform.position = exitPosition.position;
        customer.IncrementSortNumber();
        //피버
        feverManager.IncrementFeverGage();
        //점수는 현재 콤보에 따라 달라지게 해보자
        scoreManager.IncrementScoreAndCombo();
        //시간도 올라야하는데?
        timeUI.IncreaseTime();
    }
    public void WrongAnswer(Customer customer)
    {
        //고객 이미지 변경
        customer.SetSprite(eCustomerState.Fail);
        customer.transform.position = exitPosition.position;
        customer.IncrementSortNumber();
        //콤보끊고 시간 게이지 감소시켜야함.
        scoreManager.SetComboZero();
        timeUI.DecreaseTime();
    }
    private void InitInfo()
    {
        timeUI.Init(true);
        feverManager.Init();
        scoreManager.Init();
    }

    public void GameOver()
    {
        //게임 오버처리
        gameOverCanvas.SetResultInfo(scoreManager.Score, scoreManager.maxCombo);
        gameOverCanvas.gameObject.SetActive(true);
    }
    public void PauseGame()
    {
        //일시정지 상태로 만들어야함.
        //멈춰야되는거는? 시간, 피버 상태일 경우 게이지 감소 멈추기
        timeUI.PauseTime();
        feverManager.PauseTime();
    }
    public void PauseCancelGame()
    {
        timeUI.PauseCancel();
        feverManager.PauseCancel();
    }
    public void RestartGame()
    {
        //다시시작을 위한 기능
        CustomerQueue.Instance.Init();
        //timeUI.PauseTime(); //처음에 멈춰놔야함

        InitInfo(); 
        gameStartCanvas.gameObject.SetActive(true);
    }
    public void RestartGame_GameEnd()
    {
        //게임 한판 끝나고 난 이후 다시 시작할때
        gameOverCanvas.gameObject.SetActive(false);
        RestartGame();
    }
}
