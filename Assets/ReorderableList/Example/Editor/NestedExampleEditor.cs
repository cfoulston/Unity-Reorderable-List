using UnityEngine;
using UnityEditor;
using System.Collections;
using Malee.Editor;
using System;

[CanEditMultipleObjects]
[CustomEditor(typeof(NestedExample))]
public class NestedExampleEditor : Editor {
	
	private SerializedProperty list;

	void OnEnable() {

		list = serializedObject.FindProperty("list");
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUILayout.PropertyField(list);

		serializedObject.ApplyModifiedProperties();
	}
}
