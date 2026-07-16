using UnityEngine;
[CreateAssetMenu(menuName = "Customer/Customer Data", fileName = "CustomerData")]
public class CustomerSO : ScriptableObject
{
    [field: SerializeField] public eStampColor answerColor { get; private set; }
    [field: SerializeField] public Customer prefab { get; private set; }
    [field: SerializeField] public int weight { get; private set; }
}
