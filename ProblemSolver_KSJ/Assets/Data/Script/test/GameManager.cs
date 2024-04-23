using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform box1;
    public Transform box2;
    public Transform circle1;
    public Transform circle2;
    public float radius1 = 0.5f;
    public float radius2 = 0.5f;
    void Update()
    {
        // �� �ڽ��� Bounds�� �����ɴϴ�.
        Bounds bounds1 = box1.GetComponent<BoxCollider>().bounds;
        Bounds bounds2 = box2.GetComponent<BoxCollider>().bounds;

        if (MyIntersects(bounds1, bounds2))
        {
            Debug.Log("Boxes are colliding!");
        }
        else
        {
            Debug.Log("No collision.");
        }

        float distance = Vector3.Distance(circle1.position, circle2.position);

        // �������� ��
        float radiusSum = radius1 + radius2;

        // �浹 �˻�
        if (distance <= radiusSum)
        {
            Debug.Log("Circles are colliding!");
        }
        else
        {
            Debug.Log("No collision.");
        }
    }

    public bool MyIntersects(Bounds b1, Bounds b2)
    {
        // �� �࿡ ���� �� Bounds�� �����ϴ��� Ȯ��
        bool xOverlap = b1.max.x >= b2.min.x && b1.min.x <= b2.max.x;
        bool yOverlap = b1.max.y >= b2.min.y && b1.min.y <= b2.max.y;
        bool zOverlap = b1.max.z >= b2.min.z && b1.min.z <= b2.max.z;

        return xOverlap && yOverlap && zOverlap; // ��� �࿡�� ��ħ�� �־�� true
    }
}
