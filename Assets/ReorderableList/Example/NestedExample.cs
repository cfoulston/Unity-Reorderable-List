using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

public class NestedExample : MonoBehaviour {

	[Reorderable]
	public ExampleChildList list;

	[System.Serializable]
	public class ExampleChild {

		[Reorderable]
		public NestedChildList nested;
	}

	[System.Serializable]
	public class NestedChild {
	}

	[System.Serializable]
	public class ExampleChildList : ReorderableArray<ExampleChild> {
	}

	[System.Serializable]
	public class NestedChildList : ReorderableArray<NestedChild> {
	}
}
