using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Malee.Editor {

	[CustomPropertyDrawer(typeof(ReorderableAttribute))]
	public class ReorderableDrawer : PropertyDrawer {

		private Dictionary<int, ReorderableList> lists = new Dictionary<int, ReorderableList>();

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

			ReorderableList list = GetList(property, GetListId(property));

			return list != null ? list.GetHeight() : EditorGUIUtility.singleLineHeight;
		}		

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

			ReorderableList list = GetList(property, GetListId(property));

			if (list != null) {

				list.DoList(EditorGUI.IndentedRect(position), label);
			}
			else {

				GUI.Label(position, "Array must extend from ReorderableArray", EditorStyles.label);
			}
		}

		private ReorderableList GetList(SerializedProperty property, int id) {

			return GetList(property, attribute as ReorderableAttribute, id, ref lists);
		}

		//
		// -- INTERNAL --
		//

		internal static int GetListId(SerializedProperty property) {

			return CombineHashCodes(property.serializedObject.targetObject.GetHashCode(), property.propertyPath.GetHashCode());
		}

		internal static ReorderableList GetList(SerializedProperty property, int id, ref Dictionary<int, ReorderableList> lists) {

			return GetList(property, null, id, ref lists);
		}

		internal static ReorderableList GetList(SerializedProperty property, ReorderableAttribute attrib, int id, ref Dictionary<int, ReorderableList> lists) {

			SerializedProperty array;

			ReorderableList list = null;

			if (IsValid(property, out array)) {

				if (!lists.TryGetValue(id, out list)) {

					if (attrib != null) {

						list = new ReorderableList(array, attrib.add, attrib.remove, attrib.draggable, ReorderableList.ElementDisplayType.Auto, attrib.elementNameProperty, GetIcon(attrib.elementIconPath));
					}
					else {

						list = new ReorderableList(array, true, true, true);
					}

					lists.Add(id, list);
				}
				else {

					list.List = array;
				}
			}

			return list;
		}

		//
		// -- PRIVATE --
		//

		private static bool IsValid(SerializedProperty property, out SerializedProperty array) {

			array = property.FindPropertyRelative("array");

			return array != null ? array.isArray : false;
		}

		private static Texture GetIcon(string path) {

			return !string.IsNullOrEmpty(path) ? AssetDatabase.GetCachedIcon(path) : null;
		}

		private static int CombineHashCodes(int h1, int h2) {

			return (((h1 << 5) + h1) ^ h2);
		}
	}
}