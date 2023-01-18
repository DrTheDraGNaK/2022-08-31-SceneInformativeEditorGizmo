using System.Security.Cryptography;
using technical.test.editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;


public class WindowShowGizmo : EditorWindow
{
    public SceneGizmoAsset scriptable;

    [MenuItem("Window/Custom/Show Gizmos")]
    static void InitWindow()
    {
        WindowShowGizmo window = GetWindow<WindowShowGizmo>();
        
        window.titleContent = new GUIContent("Gizmos Editor");
        window.Show();
    }


    void OnEnable()
    {
        SceneView.duringSceneGui += this.OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.duringSceneGui -= this.OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        if (SceneView.lastActiveSceneView != null)
        {
            // Do your drawing here using Handles.

            for (int i = 0; i < scriptable.Gizmos.Length; i++)
            {
                if (scriptable.Gizmos[i].isEditing)
                {
                    Handles.DoPositionHandle(scriptable.Gizmos[i].Position, Quaternion.identity);
                    Handles.Label(scriptable.Gizmos[i].Position + Vector3.up * 2,
            scriptable.Gizmos[i].Position.ToString() + scriptable.Gizmos[i].Name);
                }
                Handles.SphereHandleCap(
              0,
                  scriptable.Gizmos[i].Position,
                  Quaternion.identity,
                  1,
                  EventType.Repaint
              );
            }          


         
            
            SceneView.lastActiveSceneView.Repaint();
        }
    }

    private void OnGUI()
    {
        scriptable = EditorGUILayout.ObjectField(scriptable, typeof(SceneGizmoAsset), false) as SceneGizmoAsset;
        GUILayout.BeginHorizontal();
        GUILayout.Label("Text");
        GUILayout.Label("position");
        GUILayout.EndHorizontal();
        if (scriptable != null)
        {
            for (int i = 0; i < scriptable.Gizmos.Length; i++)
            {
                Gizmo newG = scriptable.Gizmos[i];
             
                EditorGUI.BeginChangeCheck();
                DrawRow(ref newG, i);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(scriptable, "Save move point");
                    EditorUtility.SetDirty(scriptable);
                    scriptable.Gizmos[i] = newG;
                }
            }
        }
    }

    void DrawRow(ref Gizmo gizmo, int id)
    {

        GUI.backgroundColor = Color.white;
        GUILayout.BeginHorizontal("box");

        EditorGUI.BeginDisabledGroup(!gizmo.isEditing);
        GUI.backgroundColor = gizmo.isEditing ? Color.red : Color.white;

        gizmo.Name = EditorGUILayout.TextField(gizmo.Name);
        gizmo.Position = EditorGUILayout.Vector3Field("", gizmo.Position);

        //EditorGUILayout.PropertyField()

        EditorGUI.EndDisabledGroup();

        if (GUILayout.Button("Edit"))
        {
            gizmo.isEditing = !gizmo.isEditing;
        }
        GUILayout.EndHorizontal();


    }
}
