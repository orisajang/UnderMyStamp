using UnityEngine;



public class Player : MonoBehaviour
{
    
    [SerializeField] GameObject playerModelObject;
    PlayerStamp playerStamp;
    private void Awake()
    {
        playerStamp = GetComponentInChildren<PlayerStamp>();
    }
    public void RequestChangeStamp()
    {
        //플레이어 모델을 변경하면 플레이어와 도장의 모델까지 좌우반전으로 전부 변경될거라 모델만 변경하면 된다
        Vector3 scale = playerModelObject.transform.localScale;
        scale.x *= -1;
        playerModelObject.transform.localScale = scale;
        playerStamp.ChangeStampColor();
    }
    public eStampColor ReturnStampColor()
    {
        return playerStamp.StampColor;
    }
}
