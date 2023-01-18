using System.Collections;
using System.Collections.Generic;
using technical.test.editor;
using UnityEditor;
using UnityEngine;

public class CreateGizmoOnScene : MonoBehaviour
{
     SceneGizmoAsset scriptable;
    void OnDrawGizmosSelected()
    {
        scriptable = EditorGUILayout.ObjectField(scriptable, typeof(SceneGizmoAsset), false) as SceneGizmoAsset;
        for (int i = 0; i < scriptable.Gizmos.Length; i++)
        {
            Gizmo newG = scriptable.Gizmos[i];
            CreateGizmo(ref newG);
            scriptable.Gizmos[i] = newG;
        }       
        
    }
    void CreateGizmo(ref Gizmo gizmo)
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawSphere(gizmo.Position, 1);
    }
}
