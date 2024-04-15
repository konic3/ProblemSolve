using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(StaticMeshGen))]
public class StaticMeshGenEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        StaticMeshGen script = (StaticMeshGen)target;

        if (GUILayout.Button("Generate Mesh"))
        {
            script.GenerateMesh();
        }

    }
}

public class StaticMeshGen : MonoBehaviour
{
    // Start is called before the first frame update
    public void GenerateMesh()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (-1.0f, -2.0f, 0.0f), //0
            new Vector3 (0.0f, 0.0f, 0.0f), //1    
            new Vector3 (1.0f, -2.0f, 0.0f), //2
            new Vector3 (3.5f, -2.0f, 0.0f), //3
            new Vector3 (1.5f, -3.5f, 0.0f), //4
            new Vector3 (2.5f, -6.0f, 0.0f), //5
            new Vector3 (0f, -4.5f, 0.0f), //6
            new Vector3 (-2.5f, -6.0f, 0.0f), //7
            new Vector3 (-1.5f, -3.5f, 0.0f), //8
            new Vector3 (-3.5f, -2.0f, 0.0f), //9
            
            new Vector3 (-1.0f, -2.0f, 4.0f), //10
            new Vector3 (0.0f, 0.0f, 4.0f), //11
            new Vector3 (1.0f, -2.0f, 4.0f), //12
            new Vector3 (3.5f, -2.0f, 4.0f), //13
            new Vector3 (1.5f, -3.5f, 4.0f), //14
            new Vector3 (2.5f, -6.0f, 4.0f), //15
            new Vector3 (0f, -4.5f, 4.0f), //16
            new Vector3 (-2.5f, -6.0f, 4.0f), //17
            new Vector3 (-1.5f, -3.5f, 4.0f), //18
            new Vector3 (-3.5f, -2.0f, 4.0f), //19
             
        };

        mesh.vertices = vertices;

        int[] triangleIndices = new int[]
        {
            //앞면
            0,1,2,
            2,3,4,
            4,5,6,
            6,7,8,
            8,9,0,
            6,8,0,
            0,2,6,
            4,6,2,

            //뒷면
            10,11,12,
            12,13,14,
            14,15,16,
            16,17,18,
            18,19,10,
            16,18,10,
            10,12,16,
            14,16,12,

            //뒷면 뒤에서
            12,11,10,
            10,19,18,
            18,17,16,
            16,15,14,
            14,13,12,
            10,18,16,
            16,12,10,
            12,16,14,

            //기둥
            1,11,12,
            12,2,1,
            2,12,13,
            13,3,2,
            3,13,14,
            14,4,3,
            4,14,15,
            15,5,4,
            5,15,16,
            16,6,5,
            6,16,17,
            17,7,6,
            7,17,18,
            18,8,7,
            8,18,19,
            19,9,8,
            9,19,10,
            10,0,9,
            0,10,11,
            11,1,0,

        };

        Vector3[] normals = new Vector3[vertices.Length];
        mesh.triangles = triangleIndices;


        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            int index1 = mesh.triangles[i];
            int index2 = mesh.triangles[i + 1];
            int index3 = mesh.triangles[i + 2];

            Vector3 v1 = vertices[index1];
            Vector3 v2 = vertices[index2];
            Vector3 v3 = vertices[index3];

            Vector3 normal = Vector3.Cross(v2 - v1, v3 - v1).normalized;

            normals[index1] += normal;
            normals[index2] += normal;
            normals[index3] += normal;
        }
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = normals[i].normalized;
        }

        for (int i = 0; i < normals.Length; i++)
        {
            Debug.Log("Vertex: " + vertices[i] + ", Normal: " + normals[i]);
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.triangles = triangleIndices;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        mf.mesh = mesh;
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

    }
}
