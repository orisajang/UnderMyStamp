using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    //목표: 자식의 오브젝트 위치로 줄을 서는 위치를 가져옴
    //초기에 랜덤 함수를 통해서 손님을 랜덤으로 생성한다.
    //그리고 손님이 한명씩 빠져야하면 다시 랜덤으로 맨 마지막 줄에 손님을 생성하면 됨
    List<Transform> queuePositionList = new List<Transform>();
    Customer[] customerArray;
    int total = 0;
    int curLineIndex = 0;
    private void Awake()
    {
        //초기 자식들의 게임오브젝트 위치로 생성 위치에 대해 지정
        for(int i=0; i< transform.childCount; i++)
        {
            queuePositionList.Add(transform.GetChild(i));
        }
        customerArray = new Customer[queuePositionList.Count];

    }
    private void Start()
    {
        foreach (CustomerSO so in ResourceManager.Instance.customerSOList)
        {
            total += so.weight;
        }
        for(int i=0; i< customerArray.Length; i++)
        {
            MakeCustomer();
        }
    }


    public void MakeCustomer()
    {
        //3명 가능, 0 1 2 3
        if (curLineIndex >= queuePositionList.Count) { return; }

        //오브젝트 풀으 통해 가져오기전에 종류부터 정해야함(랜덤으로)
        int selIndex = GetRandomIndex();
        CustomerSO selSO = ResourceManager.Instance.customerSOList[selIndex];
        //오브젝트 풀을 통해 가져오고 위치를 현재 줄 위치로 지정해주자
        Transform trf = queuePositionList[curLineIndex];
        Customer customer = CustomerSpawner.Instance.GetCustomerByPool(selSO, trf);
        customerArray[curLineIndex] = customer;
        curLineIndex++;
    }
    public int GetRandomIndex()
    {
        List<CustomerSO> customerList = ResourceManager.Instance.customerSOList;
        int rand = Random.Range(0, total);
        int sum = 0;
        int selIndex = 0;
        for (int i = 0; i < customerList.Count; i++)
        {
            sum += customerList[i].weight;
            if (rand < sum)
            {
                selIndex = i;
                break;
            }
        }
        return selIndex;

        
    }





}
