using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eStampColor
{
    Green, Red
}
public class PlayerStamp : MonoBehaviour
{
    [SerializeField] List<Sprite> stampSpriteList = new List<Sprite>();
    [SerializeField] Transform handTransform;
    [SerializeField] GameObject stampModelObject;
    SpriteRenderer stempRenderer;
    public eStampColor StampColor { get; private set; }

    StampEffectScript effectScript;

    float delayTime = 1f;
    WaitForSeconds delay;
    Coroutine showEffectCor;

    private void Awake()
    {
        stempRenderer = GetComponentInChildren<SpriteRenderer>();
        effectScript = GetComponentInChildren<StampEffectScript>();
        delay = new WaitForSeconds(delayTime);
    }
    public void ChangeStampColor()
    {
        switch (StampColor)
        {
            case eStampColor.Green:
                StampColor = eStampColor.Red;
                break;
            case eStampColor.Red:
                StampColor = eStampColor.Green;
                break;
        }
        //스탬프 색깔을 바꿈
        stempRenderer.sprite = stampSpriteList[(int)StampColor];
    }
    public void ShowStampEffect()
    {
        switch (StampColor)
        {
            case eStampColor.Green:
                effectScript.ShowGreenStampEffect();
                break;
            case eStampColor.Red:
                effectScript.ShowRedStampEffect();
                break;
        }
    }


    public void InitStampEffect()
    {
        effectScript.Init();
    }
}
