using UnityEngine;

namespace Malee {

	public class ReorderableAttribute : PropertyAttribute {

		public bool add;
		public bool remove;
		public bool draggable;
		public string elementNameProperty;
		public string elementIconPath;

		public ReorderableAttribute()
			: this(null) {
		}

		public ReorderableAttribute(string elementNameProperty)
			: this(true, true, true, elementNameProperty) {
		}

		public ReorderableAttribute(string elementNameProperty, string elementIconPath)
			: this(true, true, true, elementNameProperty, elementIconPath) {
		}

		public ReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null) {

			this.add = add;
			this.remove = remove;
			this.draggable = draggable;
			this.elementNameProperty = elementNameProperty;
			this.elementIconPath = elementIconPath;
		}
	}
}