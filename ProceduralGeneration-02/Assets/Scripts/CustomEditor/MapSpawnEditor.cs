using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TreeMeshCombiner))]
public class MapSpawnEditor : Editor
{

    public override void OnInspectorGUI()
    {
        TreeMeshCombiner meshCombiner = (TreeMeshCombiner)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Spawn"))
            meshCombiner.SpawnTree();
        else if (GUILayout.Button("Reset"))
            meshCombiner.ClearPlayground();
        else if (GUILayout.Button("Combine"))
            meshCombiner.CombineMeshes();
    }
}
