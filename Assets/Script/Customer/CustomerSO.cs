using UnityEngine;

public enum eCustomerState
{
    Basic, Success, Fail
}

[CreateAssetMenu(menuName = "Customer/Customer Data", fileName = "CustomerData")]
public class CustomerSO : ScriptableObject
{
    [field: SerializeField] public eStampColor answerColor { get; private set; }
    [field: SerializeField] public Customer prefab { get; private set; }
    [field: SerializeField] public int weight { get; private set; }
    [field: SerializeField] public Sprite basicImage { get; private set; }
    [field: SerializeField] public Sprite failImage { get; private set; }
    [field: SerializeField] public Sprite successImage { get; private set; }


}
