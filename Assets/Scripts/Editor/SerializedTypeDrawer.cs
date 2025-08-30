using Data;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace App.Editor
{
    [CustomPropertyDrawer(typeof(SerializedType))]
    public class SerializedTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty asmNameProp = property.FindPropertyRelative("_assemblyQualifiedName");
            Type currentType = !string.IsNullOrEmpty(asmNameProp.stringValue) ? Type.GetType(asmNameProp.stringValue) : null;

            EditorGUI.BeginProperty(position, label, property);

            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                                                  .SelectMany(a => a.GetTypes())
                                                  .Where(t => typeof(MonoBehaviour).IsAssignableFrom(t) && !t.IsAbstract)
                                                  .OrderBy(t => t.Name)
                                                  .ToList();

            string[] displayedOptions = allTypes.Select(t => t.FullName).Prepend("<None>").ToArray();
            int currentIndex = currentType == null ? 0 : allTypes.IndexOf(currentType) + 1;

            int newIndex = EditorGUI.Popup(position, label.text, currentIndex, displayedOptions);

            if (newIndex == 0)
                asmNameProp.stringValue = null;
            else if (newIndex > 0)
                asmNameProp.stringValue = allTypes[newIndex - 1].AssemblyQualifiedName;

            EditorGUI.EndProperty();
        }
    }
}