using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GrassElevator))]
public class GrassElevatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Elevate Grass"))
        {
            string nameSearch = serializedObject.FindProperty("nameSearch").stringValue;
            float start = serializedObject.FindProperty("raiseSearchPoint").floatValue;
            float offset = serializedObject.FindProperty("offset").floatValue;

            foreach (GameObject o in FindObjectsOfType<GameObject>())
            {
                if (o.name.Contains(nameSearch))
                {
                    RaycastHit hit;

                    if (Physics.Raycast(o.transform.position + Vector3.up * start, Vector3.down, out hit, Mathf.Infinity, 1 << 8, QueryTriggerInteraction.UseGlobal))
                    {
                        Undo.RecordObject(o, "Moved Grass");
                        Vector3 pos = hit.point + Vector3.up * offset;
                        Debug.Log("Moved " + o.name + " to " + pos);
                        o.transform.position = pos;
                    }
                }
            }
        }
    }
}