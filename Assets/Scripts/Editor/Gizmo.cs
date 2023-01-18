using System;
using UnityEditor;
using UnityEngine;


namespace technical.test.editor
{
    [Serializable]
    public struct Gizmo
    {
        public bool isEditing;
        public string Name;   
        public Vector3 Position;

        public Gizmo(string name, Vector3 position)
        {
            isEditing = false;

            Name = name;
            Position = position;
        }        

    }    


}