using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EarnedTextManager : MonoBehaviour
{
    public static EarnedTextManager Instance { get; private set; }
    List<EarnedTextAnimation> earnedTextList = new List<EarnedTextAnimation>();

    int index = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        earnedTextList = GetComponentsInChildren<EarnedTextAnimation>(true).ToList(); //비활성화 된 객체도 가져온다
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }


    public EarnedTextAnimation ShowText(string str)
    {
        EarnedTextAnimation text = earnedTextList[index];
        text.Show(str);
        index = (index + 1) % earnedTextList.Count;
        return text;
    }
    public void ReturnText()
    {
        //필요없을듯? 그냥 한번 딱 표시하고 끝내면 되는데

    }


}
