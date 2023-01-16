using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using technical.test.editor;

[CustomEditor(typeof(SceneGizmoAsset))]
public class ScriptableObjEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (SceneGizmoAsset)target;

        if (GUILayout.Button("Open Gizmos Editor Window"))
        {
            WindowShowGizmo window = (WindowShowGizmo)EditorWindow.GetWindow(typeof(WindowShowGizmo));
            window.Show();
        }

    }
}
