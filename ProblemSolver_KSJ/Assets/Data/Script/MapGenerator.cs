using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using static UnityEngine.GraphicsBuffer;

public class MapGenerator : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject temp;
    public int sizex = 5;
    public int sizez = 5;
    #if UNITY_EDITOR
        [CustomEditor(typeof(MapGenerator))]
        public class RandomObjectGeneratorEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                //MapGenerator generator = (MapGenerator)target;

            }
        }
    #endif

    void Start()
    {
        string filePath = "Assets/wall.csv";
        string[] lines = File.ReadAllLines(filePath);
        string[,] data = new string[lines.Length, lines[0].Split(',').Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] columns = lines[i].Split(',');

            // 각 열을 처리
            for (int j = 0; j < columns.Length; j++)
            {
                data[i, j] = columns[j];
            }
        }
        float x = -3.5f;
        float z = -14.5f;

        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                GameObject wallObejct;

                switch (data[i, j])
                {
                    case "0":
                        break;
                    case "1":
                        wallObejct = Instantiate(wall1,temp.transform);
                        wallObejct.transform.position = new Vector3(x, -3.5f, z);
                        break;
                    case "2":
                        wallObejct = Instantiate(wall2, temp.transform);
                        wallObejct.transform.position = new Vector3(x, -3f, z);
                        break;
                }
                x += 1f;
            }
            x = -3.5f;
            z += 1f;
        }
    }
    private void OnDrawGizmosSelected()
    {
            // 원 형태의 가이드라인을 그립니다.
            Handles.color = Color.yellow;
            //Handles.DrawWireDisc(transform.position, transform.up, Radius);
            Handles.DrawWireCube(transform.position, new Vector3(sizex, 0.25f, sizez));

    }
    
}
  