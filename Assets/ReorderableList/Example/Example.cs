using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Malee;

public class Example : MonoBehaviour {
	
	public List<ExampleChild> list1;

	[Reorderable(elementNameProperty = "layerMask")]
	public ExampleChildList list2;

	public List<ExampleChild> list3;

	[System.Serializable]
	public class ExampleChild {

		public string name;
		public float value;
		public ExampleEnum myEnum;
		public LayerMask layerMask;

		public enum ExampleEnum {
			EnumValue1,
			EnumValue2,
			EnumValue3
		}
	}

	[System.Serializable]
	public class ExampleChildList : ReorderableArray<ExampleChild> {
	}
}
