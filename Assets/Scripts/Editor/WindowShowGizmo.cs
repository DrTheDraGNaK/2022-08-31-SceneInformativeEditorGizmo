using System.Collections;
using System.Collections.Generic;
using technical.test.editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UIElements;

public class WindowShowGizmo : EditorWindow
{
    public SceneGizmoAsset scriptable;
    string fileName = "texte";

    [MenuItem("Window/Custom/Show Gizmos")]
    static void InitWindow()
    {
        WindowShowGizmo window = GetWindow<WindowShowGizmo>();

        window.titleContent = new GUIContent("Gizmos Editor");
        window.Show();
    }
    private void OnGUI()
    {
        scriptable = EditorGUILayout.ObjectField(scriptable, typeof(SceneGizmoAsset), false) as SceneGizmoAsset;

        for (int i = 0; i < scriptable.Gizmos.Length; i++)
        {
            Gizmo newG = scriptable.Gizmos[i];
            DrawRow(ref newG);

            scriptable.Gizmos[i] = newG;
        }
    }

    void DrawRow(ref Gizmo gizmo)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Text");
        GUILayout.Label("position");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        gizmo.Name = EditorGUILayout.TextField(gizmo.Name);
        gizmo.Position = EditorGUILayout.Vector3Field("", gizmo.Position);
        if (GUILayout.Button("Edit"))
        {
            Debug.Log(fileName);
        }
        GUILayout.EndHorizontal();
    }
}
