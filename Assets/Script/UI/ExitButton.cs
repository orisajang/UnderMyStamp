using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    RectTransform rect;
    Button exitButton;
    Image buttonImage;
    TextMeshProUGUI buttonText;
    [SerializeField] Image buttonIcon;
    [SerializeField] Sprite basicSprite;
    [SerializeField] Sprite pleaseSprite;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        exitButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        exitButton.onClick.AddListener(OnExitButtonClick);
    }
    private void OnEnable()
    {
        rect.localScale = new Vector3(1f, 1f, 1f);
        exitButton.interactable = true;
        buttonImage.sprite = basicSprite;
        buttonText.gameObject.SetActive(true);
        buttonIcon.gameObject.SetActive(true);
        
    }
    private void OnDestroy()
    {
        exitButton.onClick.RemoveAllListeners();
    }

    private void OnExitButtonClick()
    {
        rect.localScale = new Vector3(2f, 3f, 1f);
        exitButton.interactable = false;
        buttonImage.sprite = pleaseSprite;
        buttonText.gameObject.SetActive(false);
        buttonIcon.gameObject.SetActive(false);
    }

}
