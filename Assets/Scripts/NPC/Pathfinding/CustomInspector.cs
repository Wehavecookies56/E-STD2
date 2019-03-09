using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(AStarNetBuilder))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AStarNetBuilder myTarget = (AStarNetBuilder)target;

        AStarNetBuilder myScript = (AStarNetBuilder)target;
        if (GUILayout.Button("Generate Pathfinding Network"))
        {
            Debug.Log("Generating a pathfinding network");
            myTarget.BuildNetwork();
        }
    }
}
#endif