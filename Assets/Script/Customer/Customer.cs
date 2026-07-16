using UnityEngine;

public class Customer : MonoBehaviour
{
    [field: SerializeField] public CustomerSO customerData { get; private set; }

    public void Init(CustomerSO data)
    {
        customerData = data;
    }
}
