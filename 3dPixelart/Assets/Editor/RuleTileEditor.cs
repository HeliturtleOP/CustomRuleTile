using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RuleTileSO))]
public class RuleTileEditor : Editor
{
    RuleTileSO so;
    private void OnEnable()
    {
        so = (RuleTileSO)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

            GUILayout.Label(Resources.Load("Placeholder_00") as Texture);
            so.wall1 = (GameObject)EditorGUILayout.ObjectField(so.wall1, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_01") as Texture);
        so.wall2 = (GameObject)EditorGUILayout.ObjectField(so.wall2, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_02") as Texture);
        so.wall3 = (GameObject)EditorGUILayout.ObjectField(so.wall3, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_03") as Texture);
        so.wall4 = (GameObject)EditorGUILayout.ObjectField(so.wall4, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_04") as Texture);
        so.wall5 = (GameObject)EditorGUILayout.ObjectField(so.wall5, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_05") as Texture);
        so.wall6 = (GameObject)EditorGUILayout.ObjectField(so.wall6, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_06") as Texture);
        so.wall7 = (GameObject)EditorGUILayout.ObjectField(so.wall7, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_07") as Texture);
        so.wall8 = (GameObject)EditorGUILayout.ObjectField(so.wall8, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_08") as Texture);
        so.wall9 = (GameObject)EditorGUILayout.ObjectField(so.wall9, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_09") as Texture);
        so.wall10 = (GameObject)EditorGUILayout.ObjectField(so.wall10, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_10") as Texture);
        so.wall11 = (GameObject)EditorGUILayout.ObjectField(so.wall11, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_11") as Texture);
        so.wall12 = (GameObject)EditorGUILayout.ObjectField(so.wall12, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_12") as Texture);
        so.wall13 = (GameObject)EditorGUILayout.ObjectField(so.wall13, typeof(Object), false);

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        GUILayout.Label(Resources.Load("Placeholder_13") as Texture);
        so.wall14 = (GameObject)EditorGUILayout.ObjectField(so.wall14, typeof(Object), false);

        GUILayout.EndHorizontal();

        EditorUtility.SetDirty(so);

    }

}
