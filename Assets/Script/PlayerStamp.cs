using System.Collections.Generic;
using UnityEngine;
public enum eStampColor
{
    Red, Green
}
public class PlayerStamp : MonoBehaviour
{
    [SerializeField] List<Sprite> stampSpriteList = new List<Sprite>();
    [SerializeField] Transform handTransform;
    [SerializeField] GameObject stampModelObject;
    SpriteRenderer stempRenderer;

    private void Awake()
    {
        stempRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    eStampColor stampColor;
    public void ChangeStampColor()
    {
        switch (stampColor)
        {
            case eStampColor.Red:
                stampColor = eStampColor.Green;
                break;
            case eStampColor.Green:
                stampColor = eStampColor.Red;
                break;
        }
        //스탬프 색깔을 바꿈
        stempRenderer.sprite = stampSpriteList[(int)stampColor];
    }
}
