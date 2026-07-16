using System;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public static CustomerSpawner Instance { get; private set; }
    //오브젝트풀 프리팹,사이즈 , 선언
    List<CustomerSO> _customerSOList; //리소스 매니저에서 받아서 만듬
    [SerializeField] int poolSize = 10;

    //딕셔너리?? 
    Dictionary<CustomerSO, ObjPool<Customer>> dict = new Dictionary<CustomerSO, ObjPool<Customer>>();
    //public event Action<int> _getExpPoint;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //_customerPool = new ObjPool<Customer>(_customerPrefab, poolSize, gameObject.transform);
    }

    private void OnEnable()
    {
        _customerSOList = ResourceManager.Instance.customerSOList;
        for (int i = 0; i < _customerSOList.Count; i++)
        {
            if (!dict.ContainsKey(_customerSOList[i]))
            {
                ObjPool<Customer> customerPool = new ObjPool<Customer>(_customerSOList[i].prefab, poolSize, gameObject.transform);
                dict.Add(_customerSOList[i], customerPool);
            }
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    //생성 코드
    public Customer GetCustomerByPool(CustomerSO dataType,Transform trf)
    {
        ObjPool<Customer> pool = dict[dataType];
        Customer expBuf = pool.GetObject();
        expBuf.Init(dataType);
        expBuf.transform.position = trf.position;
        //expBuf._destroyExpPoint += ReturnExpPointToPool;
        return expBuf;
    }
    //오브젝트 반환 (반환이벤트없으면 public으로 써도됨)
    private void ReturnCustomerToPool(CustomerSO dataType, Customer expPoint)
    {
        ObjPool<Customer> pool = dict[dataType];
        pool.ReturnObject(expPoint);
        //expPoint._destroyExpPoint -= ReturnExpPointToPool;

        //경험치를 주웠을때 
        //_getExpPoint?.Invoke(10);
    }
}
