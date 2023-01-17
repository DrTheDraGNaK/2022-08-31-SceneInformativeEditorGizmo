using UnityEngine;

namespace technical.test.editor
{
    [CreateAssetMenu(fileName = "Scene Gizmo Asset", menuName = "Custom/Create Scene Gizmo Asset")]
    public class SceneGizmoAsset : ScriptableObject
    {
        internal Transform transform;
        [SerializeField] private Gizmo[] _gizmos = default;   
        public Gizmo[] Gizmos { get { return _gizmos; } }


        public override string ToString()
        {
            return "Gizmo count : " + _gizmos.Length;
        }

        
    }

}