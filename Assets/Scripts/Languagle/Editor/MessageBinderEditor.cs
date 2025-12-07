using UnityEditor;
using UnityEngine;
using System.Reflection;

[CustomEditor(typeof(LanguageSelector))]
public class MessageBinderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var binder = (LanguageSelector)target;

        DrawDefaultInspector(); // draw selector & target normally

        var fields = typeof(Language)
            .GetFields(BindingFlags.Public | BindingFlags.Instance);

        string[] options = new string[fields.Length];
        for (int i = 0; i < fields.Length; i++)
        {
            options[i] = fields[i].Name;
        }

        int currentIndex = System.Array.IndexOf(options, binder.fieldName);
        int newIndex = EditorGUILayout.Popup("Field Name", currentIndex, options);

        if (newIndex != currentIndex)
        {
            binder.fieldName = options[newIndex];
            EditorUtility.SetDirty(binder); // mark dirty so Unity saves it
        }
    }
}