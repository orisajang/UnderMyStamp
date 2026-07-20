using UnityEngine;
using UnityEngine.Rendering;

public class Customer : MonoBehaviour
{
    private static int sortingCounter = 0;
    [field: SerializeField] public CustomerSO customerData { get; private set; }
    SpriteRenderer spriteRenderer;

    SortingGroup sortingGroup;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        sortingGroup = GetComponent<SortingGroup>();
        //초기에 Data에 있는 basic 이미지를 넣어준다
        spriteRenderer.sprite =  customerData.basicImage;
    }
    public void Init(CustomerSO data)
    {
        customerData = data;
        spriteRenderer.sprite = customerData.basicImage;
    }
    public void SetSprite(eCustomerState state)
    {
        Sprite sprite = null;
        switch (state)
        {
            case eCustomerState.Basic:
                sprite = customerData.basicImage;
                break;
            case eCustomerState.Success:
                sprite = customerData.successImage;
                break;
            case eCustomerState.Fail:
                sprite = customerData.failImage;
                break;
        }
        spriteRenderer.sprite = sprite;
    }
    public void IncrementSortNumber()
    {
        sortingGroup.sortingOrder = ++sortingCounter;
        if(sortingCounter >= int.MaxValue)
        {
            sortingCounter = 0;
        }
    }
}
