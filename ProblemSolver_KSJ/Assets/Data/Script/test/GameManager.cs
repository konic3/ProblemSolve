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
        // 각 박스의 Bounds를 가져옵니다.
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

        // 반지름의 합
        float radiusSum = radius1 + radius2;

        // 충돌 검사
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
        // 각 축에 대해 두 Bounds가 교차하는지 확인
        bool xOverlap = b1.max.x >= b2.min.x && b1.min.x <= b2.max.x;
        bool yOverlap = b1.max.y >= b2.min.y && b1.min.y <= b2.max.y;
        bool zOverlap = b1.max.z >= b2.min.z && b1.min.z <= b2.max.z;

        return xOverlap && yOverlap && zOverlap; // 모든 축에서 겹침이 있어야 true
    }
}
