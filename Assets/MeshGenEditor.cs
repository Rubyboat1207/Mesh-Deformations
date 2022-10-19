using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshGenerator))]
public class MeshGenEditor : Editor {
    public override void OnInspectorGUI() {
        MeshGenerator myTarget = (MeshGenerator) target;
        //base.OnInspectorGUI();
        myTarget.xSize = EditorGUILayout.IntField(myTarget.xSize);
        myTarget.zSize = EditorGUILayout.IntField(myTarget.zSize);
        myTarget.density = EditorGUILayout.IntSlider(myTarget.density, 1, 12);

        if(GUILayout.Button("Reload")) {
            myTarget.DrawMesh();
        }
    }
}