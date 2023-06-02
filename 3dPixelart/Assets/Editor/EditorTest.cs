using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapInterpreter))]
public class EditorTest : Editor
{



    public override void OnInspectorGUI()
    {


        base.OnInspectorGUI();

        MapInterpreter generator = (MapInterpreter)target;



        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate Level"))
        {
            generator.ClearLevel();
            generator.MapToArray();
        }

        if (GUILayout.Button("Clear Level"))
        {
            generator.ClearLevel();

        }

        GUILayout.EndHorizontal();
    }

}
