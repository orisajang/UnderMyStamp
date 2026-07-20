using System.Collections.Generic;
using UnityEngine;

public class StampEffectScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer redStamp;
    [SerializeField] private SpriteRenderer greenStamp;

    public void ShowRedStampEffect()
    {
        redStamp.gameObject.SetActive(true);
        greenStamp.gameObject.SetActive(false);
    }
    public void ShowGreenStampEffect()
    {
        redStamp.gameObject.SetActive(false);
        greenStamp.gameObject.SetActive(true);
    }
    public void Init()
    {
        redStamp.gameObject.SetActive(false);
        greenStamp.gameObject.SetActive(false);
    }

}
