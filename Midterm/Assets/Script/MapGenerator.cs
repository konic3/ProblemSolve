using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapGenerator : MonoBehaviour
{
    public int x=5;
    public int z=5;    
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



    private void OnDrawGizmosSelected()
    {
        // 원 형태의 가이드라인을 그립니다.
        Handles.color = Color.yellow;
        //Handles.DrawWireDisc(transform.position, transform.up, Radius);
        Handles.DrawWireCube(transform.position,new Vector3(x,0.25f,z));

    }
}
