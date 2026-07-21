using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer basicBackground;
    [SerializeField] List<SpriteRenderer> feverBackgroundList;
    [SerializeField] float delayTime = 1;
    WaitForSeconds delay;
    Coroutine cor;
    int index = 0;

    private void Awake()
    {
        delay = new WaitForSeconds(delayTime);
    }

    public void FeverStart()
    {
        index = 0;
        if(cor == null)
        {
            cor = StartCoroutine(FeverCor());
        }
        //basicBackground.gameObject.SetActive(false);
    }
    public void FeverEnd()
    {
        if(cor != null)
        {
            StopCoroutine(cor);
            cor = null;
        }
        foreach (var bg in feverBackgroundList)
        {
            bg.gameObject.SetActive(false);
        }
        //basicBackground.gameObject.SetActive(true);
    }

    IEnumerator FeverCor()
    {
        while(true)
        {
            int curIndex = index % feverBackgroundList.Count;
            for (int i = 0; i < feverBackgroundList.Count; i++ )
            {
                if(i == curIndex)
                {
                    feverBackgroundList[i].gameObject.SetActive(true);
                }
                else
                {
                    feverBackgroundList[i].gameObject.SetActive(false);
                }
            }
            index++;
            yield return delay;
        }
        
    }
}
