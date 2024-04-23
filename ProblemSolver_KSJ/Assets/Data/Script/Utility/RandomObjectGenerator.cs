using UnityEngine;
using UnityEditor;

public class RandomObjectGenerator : MonoBehaviour
{
    public GameObject TargetObject;
    public float Radius = 10.0f; // ���� ������ ����
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
        // �� ���� Object�� �����ϰ� ��ġ�ϴ� �ڵ带 �ۼ��ϼ���.
        for (int i = 0; i < ObjectNumber; i++)
        {
            // ������ ��ġ�� �����մϴ�.
            Vector2 randomCircle = Random.insideUnitCircle * Radius;
            Vector3 randomPosition = transform.position + new Vector3(randomCircle.x, 0.0f, randomCircle.y);

            // TargetObject�� �����ϰ� ������ ��ġ�� ��ġ�մϴ�.
            GameObject newObject = Instantiate(TargetObject, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // �� ������ ���̵������ �׸��ϴ�.
        Handles.color = Color.yellow;
        Handles.DrawWireDisc(transform.position, transform.up, Radius);
    }
}
