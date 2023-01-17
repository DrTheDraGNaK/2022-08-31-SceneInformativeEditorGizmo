using technical.test.editor;
using UnityEditor;
using UnityEngine;


public class WindowShowGizmo : EditorWindow
{
    public SceneGizmoAsset scriptable;

    bool buttonDown = false;

    int actualButton;
    

    [MenuItem("Window/Custom/Show Gizmos")]
    static void InitWindow()
    {
        WindowShowGizmo window = GetWindow<WindowShowGizmo>();

        window.titleContent = new GUIContent("Gizmos Editor");
        window.Show();
    }
    private void Awake()
    {
        buttonDown = false;
        actualButton = -1;

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
                DrawRow(ref newG, i);
                scriptable.Gizmos[i] = newG;
                
            }

        }
        
    }
    void DrawRow(ref Gizmo gizmo, int id)
    {
        
        GUI.backgroundColor = Color.white;
        GUILayout.BeginHorizontal("box");
        if(actualButton == id && buttonDown == true)
        {
            GUI.backgroundColor = Color.red;
            gizmo.Name = EditorGUILayout.TextField(gizmo.Name);
            gizmo.Position = EditorGUILayout.Vector3Field("", gizmo.Position);
        }
        else
        {
            EditorGUILayout.TextField(gizmo.Name);
            EditorGUILayout.Vector3Field("", gizmo.Position);

        }
        if (GUILayout.Button("Edit"))
        {
            if(buttonDown == false)
            {
                CanInteract(id);
            }
            else
            {                
                StopInteract(id);
            }
        }
        GUILayout.EndHorizontal();

        
    }
    
    public void CanInteract(int gizmoID)
    {
        actualButton = gizmoID;
        Debug.Log("Je peux interagir avec le gizmo");
        buttonDown = true;
    }
    public void StopInteract(int gizmoID)
    {
        if(actualButton == gizmoID)
        {
            Debug.Log("Je stop les interactions avec le gizmo");
            buttonDown = false;
            actualButton = -1;
        }
        
    }
}
