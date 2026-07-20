using UnityEngine;
using UnityEngine.UI;


public enum ePlayerState
{
    Idle, Stamp
}


public class Player : MonoBehaviour
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] GameObject playerModelObject;
    [SerializeField] Sprite idleImage;
    [SerializeField] Sprite crashStampImage;

    //스탬프
    PlayerStamp playerStamp;
    [SerializeField] GameObject playerStampModel;
    public ePlayerState playerState { get; private set; }
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
    public void UpdatePlayerSprite()
    {
        switch(playerState)
        {
            case ePlayerState.Idle:
                playerSprite.sprite = idleImage;
                break;
            case ePlayerState.Stamp:
                playerSprite.sprite = crashStampImage;
                break;
        }
    }
    public eStampColor ReturnStampColor()
    {
        return playerStamp.StampColor;
    }
    public void ShowStampEffect()
    {
        playerStampModel.gameObject.SetActive(false);
        playerState = ePlayerState.Stamp;
        playerStamp.ShowStampEffect();
        UpdatePlayerSprite();
    }
    public void StopStampEffect()
    {
        playerStampModel.gameObject.SetActive(true);
        playerState = ePlayerState.Idle;
        playerStamp.InitStampEffect();
        UpdatePlayerSprite();
    }
}
