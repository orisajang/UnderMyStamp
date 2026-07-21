using UnityEngine;
using UnityEngine.UI;

public class AdmitStampUI : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(OnAdmitButton);
    }
    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }
    //버튼을 클릭하면 2가지 행동을 해야함. 1) 손님줄에서 1명 줄이고, 다시 생성
    //2) 현재 플레이어의 도장색과 손님의 색을 비교해서 맞으면 true 틀리면 false
    private void OnAdmitButton()
    {
        Customer customer = CustomerQueue.Instance.ReturnCustomer();
        if (customer == null) return;
        //이펙트와 사운드
        GameManager.Instance.ShowStampEffect();
        SoundManager.Instance.PlaySFX(eSoundType.StampSound);
        //결과 확인
        BattleManager.Instance.CheckResult(customer);
        
    }

}
