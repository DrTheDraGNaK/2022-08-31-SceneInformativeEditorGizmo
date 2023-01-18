using System.Security.Cryptography;
using technical.test.editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;


public class WindowShowGizmo : EditorWindow
{
    public SceneGizmoAsset scriptable;

    float thickness = 0f;


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
                    


                }
                Handles.color = Color.white;
                Handles.SphereHandleCap(
              0,
                  scriptable.Gizmos[i].Position,
                  Quaternion.identity,
                  1,
                  EventType.Repaint
              );
                GUIStyle style = new GUIStyle();
                style.normal.textColor = Color.black;
                Handles.color = Color.black;
                Handles.Label(scriptable.Gizmos[i].Position + Vector3.up * 1, scriptable.Gizmos[i].Name, style);

                Handles.DrawLine(scriptable.Gizmos[i].Position, scriptable.Gizmos[i].Position + Vector3.up * 1, thickness);
                
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
