using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptableObjectSelectorWindow : EditorWindow
{
    private string typeName = "";

    [MenuItem("Tools/Select ScriptableObjects/By Type...")]
    public static void ShowWindow()
    {
        GetWindow<ScriptableObjectSelectorWindow>("Select ScriptableObjects");
    }

    private void OnGUI()
    {
        GUILayout.Label("Seleccionar ScriptableObjects por tipo", EditorStyles.boldLabel);
        typeName = EditorGUILayout.TextField("Nombre de clase:", typeName);

        if (GUILayout.Button("Seleccionar"))
        {
            SelectScriptableObjects(typeName);
        }
    }

    private void SelectScriptableObjects(string targetTypeName)
    {
        string[] guids = AssetDatabase.FindAssets("t:ScriptableObject");
        List<Object> matchingObjects = new List<Object>();

        Debug.Log($"Buscando ScriptableObjects del tipo: {targetTypeName}");

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Object obj = AssetDatabase.LoadAssetAtPath<Object>(path);

            if (obj != null && obj.GetType().Name == targetTypeName)
            {
                matchingObjects.Add(obj);
                Debug.Log($"✔ Encontrado: {obj.name} ({path})");
            }
        }

        if (matchingObjects.Count > 0)
        {
            Selection.objects = matchingObjects.ToArray();
            Debug.Log($"✅ Seleccionados {matchingObjects.Count} objetos de tipo {targetTypeName}.");
        }
        else
        {
            EditorUtility.DisplayDialog("Sin resultados", $"No se encontraron ScriptableObjects del tipo {targetTypeName}.", "OK");
        }
    }
}




