using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyObj;
    public int x = 5;
    public int z = 5;
    public bool isL = true;
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
        Handles.DrawWireCube(transform.position, new Vector3(x, 0.25f, z));

    }


    private void Update()
    {
        if (isL == true)
        {
            EnemyObj.transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }else if(isL == false)
        {
            EnemyObj.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isL = !isL; // 이동 방향 변경
            if (isL)
            {
                Debug.Log("Moving Left");
            }
            else
            {
                Debug.Log("Moving Right");
            }
        }
    }



}
