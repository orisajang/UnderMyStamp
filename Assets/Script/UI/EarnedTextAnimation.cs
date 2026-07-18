using DG.Tweening;
using TMPro;
using UnityEngine;

public class EarnedTextAnimation : MonoBehaviour
{
    [SerializeField] float height = 80f;

    [SerializeField] TextMeshProUGUI text;
    Sequence sequence;
    Vector3 originPos;

    private void Awake()
    {
        originPos = transform.localPosition;
    }

    public void Show(string score)
    {
        gameObject.SetActive(true);
        text.text = score;
        text.alpha = 1f;

        transform.localPosition = originPos;
        transform.localScale = Vector3.one;

        Vector3 targetPos = originPos + Vector3.up * height;
        sequence?.Kill();
        sequence = DOTween.Sequence();
        //위로 이동하면서 커지게
        sequence.Append(transform.DOScale(2f, 0.8f).SetEase(Ease.OutBack));
        sequence.Join(transform.DOLocalMove(targetPos, 0.8f).SetEase(Ease.OutQuad));

        //1초 유지
        sequence.AppendInterval(1f);
        //서서히 사라짐
        sequence.Append(text.DOFade(0f, 0.4f));

        sequence.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });


    }
}
