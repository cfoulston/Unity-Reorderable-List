using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;

public class GameObjectExample : MonoBehaviour {

	//There's a bug with Unity and rendering when an Object has no CustomEditor defined. As in this example
	//The list will reorder correctly, but depth sorting and animation will not update :(
	[Reorderable]
	public GameObjectList list;

	[System.Serializable]
	public class GameObjectList : ReorderableArray<GameObject> {
	}
}
