using System;
using UnityEngine;
using UnityEngine.UI;

public class FeverBarUI : MonoBehaviour
{
    [SerializeField] Image barImage;

    public void SetImageRatio(float ratio)
    {
        barImage.fillAmount = ratio;
    }


}
