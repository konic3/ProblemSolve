using UnityEngine;
using UnityEditor;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject TargetObject;
    public float Radius = 10.0f; // 원의 반지름 설정
    public int ObjectNumber = 0;

#if UNITY_EDITOR
    [CustomEditor(typeof(RandomObjectGenerator))]
    public class RandomObjectGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            RandomObjectGenerator generator = (RandomObjectGenerator)target;
            if (GUILayout.Button("Generate Objects"))
            {
                generator.GenerateObjects();
            }
        }
    }
#endif

    public void GenerateObjects()
    {
        // 이 곳에 Object를 생성하고 배치하는 코드를 작성하세요.
        for (int i = 0; i < ObjectNumber; i++)
        {
            // 랜덤한 위치를 생성합니다.
            Vector2 randomCircle = Random.insideUnitCircle * Radius;
            Vector3 randomPosition = transform.position + new Vector3(randomCircle.x, 0.0f, randomCircle.y);

            // TargetObject를 생성하고 랜덤한 위치에 배치합니다.
            GameObject newObject = Instantiate(TargetObject, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // 원 형태의 가이드라인을 그립니다.
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, transform.up, Radius);
    }
}
