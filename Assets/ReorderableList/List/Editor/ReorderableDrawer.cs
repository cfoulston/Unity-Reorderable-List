using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Malee.Editor {

	[CustomPropertyDrawer(typeof(ReorderableAttribute))]
	public class ReorderableDrawer : PropertyDrawer {

		private static Dictionary<int, ReorderableList> lists = new Dictionary<int, ReorderableList>();

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {

			ReorderableList list = GetList(property, attribute as ReorderableAttribute);

			return list != null ? list.GetHeight() : EditorGUIUtility.singleLineHeight;
		}		

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

			ReorderableList list = GetList(property, attribute as ReorderableAttribute);

			if (list != null) {

				list.DoList(EditorGUI.IndentedRect(position), label);
			}
			else {

				GUI.Label(position, "Array must extend from ReorderableArray", EditorStyles.label);
			}
		}

		public static int GetListId(SerializedProperty property) {

			if (property != null) {

				int h1 = property.serializedObject.targetObject.GetHashCode();
				int h2 = property.propertyPath.GetHashCode();

				return (((h1 << 5) + h1) ^ h2);
			}

			return 0;
		}

		public static ReorderableList GetList(SerializedProperty property) {

			return GetList(property, null, GetListId(property));
		}

		public static ReorderableList GetList(SerializedProperty property, ReorderableAttribute attrib) {

			return GetList(property, attrib, GetListId(property));
		}

		public static ReorderableList GetList(SerializedProperty property, int id) {

			return GetList(property, null, id);
		}

		public static ReorderableList GetList(SerializedProperty property, ReorderableAttribute attrib, int id) {

			if (property == null) {

				return null;
			}

			ReorderableList list = null;
			SerializedProperty array = property.FindPropertyRelative("array");

			if (array != null && array.isArray) {

				if (!lists.TryGetValue(id, out list)) {

					if (attrib != null) {

						Texture icon = !string.IsNullOrEmpty(attrib.elementIconPath) ? AssetDatabase.GetCachedIcon(attrib.elementIconPath) : null;

						list = new ReorderableList(array, attrib.add, attrib.remove, attrib.draggable, ReorderableList.ElementDisplayType.Auto, attrib.elementNameProperty, attrib.elementNameOverride, icon);
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
	}
}