using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //[SerializeField] Player plr;
    public static BattleManager Instance { get; private set; }
    Player plr;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        plr = GameManager.Instance.currentPlayer;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void CheckResult(Customer customer)
    {
        eStampColor plrStampColor = plr.ReturnStampColor();
        eStampColor stampColor = customer.customerData.answerColor;

        if(GameManager.Instance.IsFever() || plrStampColor == stampColor)
        {
            //정답. 처리를 진행하자
            GameManager.Instance.CorrectAnswer(customer);
        }
        else
        {
            //오답. 
            GameManager.Instance.WrongAnswer(customer);
        }

    }

}
