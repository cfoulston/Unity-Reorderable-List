using UnityEngine;
using UnityEditor;
using System.Collections;
using Malee.Editor;
using System.Collections.Generic;

[CanEditMultipleObjects]
[CustomEditor(typeof(NestedExample))]
public class NestedExampleEditor : Editor {
	
	private SerializedProperty list;
	private List<ReorderableList> nestedLists;

	void OnEnable() {

		list = serializedObject.FindProperty("list");
	}

	private void OnDisable() {

		//cleanup nestedList callbacks

		if (nestedLists != null) {

			foreach (ReorderableList list in nestedLists) {

				list.getElementNameCallback -= GetElementName;
			}

			nestedLists.Clear();
		}
	}

	public override void OnInspectorGUI() {

		serializedObject.Update();

		EditorGUI.BeginChangeCheck();

		EditorGUILayout.PropertyField(list);

		//check for any changes on the list or whether we have created a list of nested lists yet
		//if true, we keep a reference to the nested lists and assign the name callback

		if (EditorGUI.EndChangeCheck() || nestedLists == null) {

			UpdateNestedLists(list.FindPropertyRelative("array"));
		}

		serializedObject.ApplyModifiedProperties();
	}

	private void UpdateNestedLists(SerializedProperty array) {

		//check if we have created nested lists yet

		if (nestedLists == null) {

			nestedLists = new List<ReorderableList>();
		}

		//first remove the element name callback from existing lists

		foreach (ReorderableList list in nestedLists) {

			list.getElementNameCallback -= GetElementName;
		}

		nestedLists.Clear();

		//loop over all nested lists in the ReorderableArray, store the reference and assign the callback

		for (int i = 0; i < array.arraySize; i++) {

			ReorderableList nestedList = ReorderableDrawer.GetList(array.GetArrayElementAtIndex(i).FindPropertyRelative("nested"));

			if (nestedList != null) {

				nestedLists.Add(nestedList);
				nestedList.getElementNameCallback += GetElementName;
			}
		}
	}

	private string GetElementName(SerializedProperty element) {

		return "My Custom Name for Element";
	}
}
