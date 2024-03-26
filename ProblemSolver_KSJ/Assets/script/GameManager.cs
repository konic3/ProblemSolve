using UnityEngine;
using System.Collections.Generic;

public class ObjectQueue : MonoBehaviour
{
    public static ObjectQueue instance;
    public static ObjectQueue Instance { get { return instance; } }

    public GameObject bulletPrefab;
    public Queue<GameObject> objectQueue;
    
    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        // 큐 초기화
        objectQueue = new Queue<GameObject>();

        // 게임 오브젝트를 Instantiate하여 큐에 추가하고 비활성화
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            EnqueueObject(obj);
        }
    }
    private void Update()
    {
        // 사용자가 마우스 클릭할 때마다 큐에서 요소를 제거하고 활성화
        if (Input.GetMouseButtonDown(0))
        {
                GameObject obj = DequeueObject();
                obj.SetActive(true);
        }
    }

    // 게임 오브젝트를 큐에 추가하는 함수
    public void EnqueueObject(GameObject obj)
    {
        objectQueue.Enqueue(obj);
    }

    // 큐에서 게임 오브젝트를 제거하고 반환하는 함수
    GameObject DequeueObject()
    {
        if (objectQueue.Count == 0)
        {
            Debug.LogWarning("Queue is empty");
            return null;
        }

        return objectQueue.Dequeue();
    }

}