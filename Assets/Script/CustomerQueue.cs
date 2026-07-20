using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerQueue : MonoBehaviour
{
    //목표: 자식의 오브젝트 위치로 줄을 서는 위치를 가져옴
    //초기에 랜덤 함수를 통해서 손님을 랜덤으로 생성한다.
    //그리고 손님이 한명씩 빠져야하면 다시 랜덤으로 맨 마지막 줄에 손님을 생성하면 됨
    public static CustomerQueue Instance { get; private set; }
    List<Transform> queuePositionList = new List<Transform>();
    List<Customer> customerList = new List<Customer>();
    int total = 0;
    int curLineIndex = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //초기 자식들의 게임오브젝트 위치로 생성 위치에 대해 지정
        for (int i=0; i< transform.childCount; i++)
        {
            queuePositionList.Add(transform.GetChild(i));
        }
    }
    IEnumerator Start()
    {
        yield return null;
        foreach (CustomerSO so in ResourceManager.Instance.customerSOList)
        {
            total += so.weight;
        }
        Init();
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
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

    public void Init()
    {
        //다시하기로 인해서 손님을 처음부터 다시 만들어야 한다면?
        curLineIndex = 0;
        foreach(var customer in customerList)
        {
            CustomerSpawner.Instance.ReturnCustomerToPool(customer);
        }
        customerList.Clear();
        for (int i = 0; i < queuePositionList.Count; i++)
        {
            MakeCustomer();
        }
    }

    public void MakeCustomer()
    {
        //3명 가능, 0 1 2 3
        if (curLineIndex >= queuePositionList.Count) { return; }
        if (customerList.Count >= queuePositionList.Count) { return; }

        //오브젝트 풀으 통해 가져오기전에 종류부터 정해야함(랜덤으로)
        int selIndex = GetRandomIndex();
        CustomerSO selSO = ResourceManager.Instance.customerSOList[selIndex];
        //오브젝트 풀을 통해 가져오고 위치를 현재 줄 위치로 지정해주자
        Transform trf = queuePositionList[curLineIndex];
        Customer customer = CustomerSpawner.Instance.GetCustomerByPool(selSO, trf);
        customerList.Add(customer);
        curLineIndex++;
    }
    public Customer ReturnCustomer()
    {        
        if (curLineIndex <= 0) return null;
        if (customerList.Count == 0) return null;
        Customer customer = customerList[0];
        customerList.RemoveAt(0);
        curLineIndex--;
        //애니메이션 처리로 인해서 n초전까지는 표시하고 후에 해당 객체를 풀에 반환할듯 (일단 바로 반환하자)
        CustomerSpawner.Instance.ReturnCustomerToPool(customer);
        // 이제 앞으로 한칸씩 땅겨야함.
        for(int i=0; i< customerList.Count; i++ )
        {
            customerList[i].transform.position = queuePositionList[i].transform.position;
        }

        //바로 다시 한명 만들어야함
        MakeCustomer();
        
        return customer;
    }



}
