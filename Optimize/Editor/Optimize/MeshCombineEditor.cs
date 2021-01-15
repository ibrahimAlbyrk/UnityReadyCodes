using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshCombine))]
public class MeshCombineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var optimize = (MeshCombine) target;
        if (GUILayout.Button("Mesh Combine")) optimize.CombineMesh();
        
        GUILayout.Space(20);
        
        if (GUILayout.Button("Open Child Object")) optimize.SetActiveChildObjects(true);
        if (GUILayout.Button("Close Child Object")) optimize.SetActiveChildObjects(false);
        
        GUILayout.Space(20);
        
        if (GUILayout.Button("Create Mesh Collider")) optimize.CreateMeshCollider();
        if (GUILayout.Button("Clear Mesh Combine")) optimize.ClearCombineMesh();
    }
}
