using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

public class RecursionTest : MonoBehaviour {

	[Reorderable]
	public Tables tables = new Tables();

	[System.Serializable]
	public class Table {

		public string name;

		[Reorderable]
		public Tables table;
	}

	[System.Serializable]
	public class Tables : ReorderableArray<Table> {
	}
}
