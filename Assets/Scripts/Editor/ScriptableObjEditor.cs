using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using technical.test.editor;

[CustomEditor(typeof(SceneGizmoAsset))]
public class ScriptableObjEditor : Editor
{
    SceneGizmoAsset source;
    public void OnEnable()
    {
        source = (SceneGizmoAsset)target;
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        if (GUILayout.Button("Open Gizmos Editor Window"))
        {
            WindowShowGizmo window = (WindowShowGizmo)EditorWindow.GetWindow(typeof(WindowShowGizmo));
            window.titleContent = new GUIContent("Gizmos Editor");
            window.scriptable = source;

            window.Show();
        }

    }
}
