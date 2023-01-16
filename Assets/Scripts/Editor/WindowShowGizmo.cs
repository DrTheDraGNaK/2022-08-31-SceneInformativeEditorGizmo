using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowShowGizmo : EditorWindow
{

    string fileName = "texte";

    Vector3Int pos;
    
    [MenuItem("Window/Custom/Show Gizmos")]
    static void InitWindow()
    {
        WindowShowGizmo window = GetWindow<WindowShowGizmo>();

        window.titleContent = new GUIContent("Gizmos Editor");
        window.Show();
    }
    
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Text");
        GUILayout.Label("position");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        fileName = EditorGUILayout.TextField(fileName);        
        pos = EditorGUILayout.Vector3IntField("",pos);
        if(GUILayout.Button("Edit"))
        {
            Debug.Log(fileName);
        }
        GUILayout.EndHorizontal();
    }
}
