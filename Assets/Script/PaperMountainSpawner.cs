using UnityEngine;

public class PaperMountainSpawner : MonoBehaviour
{
    public static PaperMountainSpawner Instance { get; private set; }

    //표시할 프리팹, 가로와 세로로 몇개씩 쌓게 생성할것인지
    [SerializeField] Paper paperPrefab;
    [SerializeField] int maxWidth = 5;
    [SerializeField] int maxHeight = 3;
    ObjPool<Paper> _paperPool;
    //전체 크기, 프리팹 이미지 가로, 세로 길이
    int maxCount = 0;
    float prefabWidth;
    float prefabHeight;
    int curWidth;
    int curHeight;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        maxCount = maxWidth * maxHeight;
        _paperPool = new ObjPool<Paper>(paperPrefab, maxCount, gameObject.transform);
        //_customerPool = new ObjPool<Customer>(_customerPrefab, poolSize, gameObject.transform);
    }
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
    private void Start()
    {
        SpriteRenderer sr = paperPrefab.GetComponent<SpriteRenderer>();
        prefabWidth =  sr.bounds.size.x;
        prefabHeight = sr.bounds.size.y;
    }

    //생성 코드 (여기서는 반환 안하고 활성화만 시키면 된다)
    //public Customer GetCustomerByPool(CustomerSO dataType, Transform trf)
    public void GetPaperByPool()
    {
        if (curWidth >= maxWidth) return;
        //현재 위치부터 확인해보자.
        float width = transform.position.x + (prefabWidth * curWidth);
        float height = transform.position.y + (prefabHeight * curHeight);
        Vector2 pos = new Vector2(width, height);
        curHeight++;
        //최대 높이로 왔다면 오른쪽으로 이동.
        if(curHeight >= maxHeight)
        {
            curHeight = 0;
            curWidth++;
        }
        Paper paperObj = _paperPool.GetObject();
        paperObj.transform.position = pos;
    }
    //오브젝트 반환 (추후에 뭔가 미리 생성된객체들이 바뀌어야한다면 여기서)
    public void ReturnCustomerToPool(Paper paper )
    {

    }
}
