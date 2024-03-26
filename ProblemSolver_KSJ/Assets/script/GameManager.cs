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
        // ť �ʱ�ȭ
        objectQueue = new Queue<GameObject>();

        // ���� ������Ʈ�� Instantiate�Ͽ� ť�� �߰��ϰ� ��Ȱ��ȭ
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            EnqueueObject(obj);
        }
    }
    private void Update()
    {
        // ����ڰ� ���콺 Ŭ���� ������ ť���� ��Ҹ� �����ϰ� Ȱ��ȭ
        if (Input.GetMouseButtonDown(0))
        {
                GameObject obj = DequeueObject();
                obj.SetActive(true);
        }
    }

    // ���� ������Ʈ�� ť�� �߰��ϴ� �Լ�
    public void EnqueueObject(GameObject obj)
    {
        objectQueue.Enqueue(obj);
    }

    // ť���� ���� ������Ʈ�� �����ϰ� ��ȯ�ϴ� �Լ�
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