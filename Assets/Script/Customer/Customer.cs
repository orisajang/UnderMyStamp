using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerSO customerData;

    public void Init(CustomerSO data)
    {
        customerData = data;
    }
}
