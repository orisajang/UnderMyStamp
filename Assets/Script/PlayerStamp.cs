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

    private void Awake()
    {
        stempRenderer = GetComponentInChildren<SpriteRenderer>();
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
}
