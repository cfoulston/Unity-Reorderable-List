using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Malee {

	[Serializable]
	public abstract class ReorderableArray<T> : ICloneable, IList<T>, ICollection<T>, IEnumerable<T> {

		[SerializeField]
		private T[] array = new T[0];

		public ReorderableArray()
			: this(0) {
		}

		public ReorderableArray(int length) {

			array = new T[length];
		}

		public T this[int index] {

			get { return array[index]; }
			set { array[index] = value; }
		}
		
		public int Length {
			
			get { return array.Length; }
		}

		public bool IsReadOnly {

			get { return array.IsReadOnly; }
		}

		public int Count {

			get { return array.Length; }
		}

		public object Clone() {

			return array.Clone();
		}

		public bool Contains(T value) {

			return Array.IndexOf(array, value) >= 0;
		}

		public int IndexOf(T value) {

			return Array.IndexOf(array, value);
		}

		public void Insert(int index, T item) {

			((IList<T>)array).Insert(index, item);
		}

		public void RemoveAt(int index) {

			((IList<T>)array).RemoveAt(index);
		}

		public void Add(T item) {

			((IList<T>)array).Add(item);
		}

		public void Clear() {

			((IList<T>)array).Clear();
		}

		public void CopyTo(T[] array, int arrayIndex) {

			((IList<T>)this.array).CopyTo(array, arrayIndex);
		}

		public bool Remove(T item) {

			return ((IList<T>)array).Remove(item);
		}

		public IEnumerator<T> GetEnumerator() {

			return ((IList<T>)array).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {

			return ((IList<T>)array).GetEnumerator();
		}

		public static implicit operator Array (ReorderableArray<T> reorderableArray) {

			return reorderableArray.array;
		}

		public static implicit operator T[](ReorderableArray<T> reorderableArray) {

			return reorderableArray.array;
		}
	}
}
