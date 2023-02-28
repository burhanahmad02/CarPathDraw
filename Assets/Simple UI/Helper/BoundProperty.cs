using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace SimpleUI
{
	[System.Serializable]
	public class BoundProperty<T> : UnityEvent<T>{
		private T PropertyValue;

		public T Value{
			get{
				return PropertyValue;
			}
			set{
				PropertyValue = value;
				Invoke(value);
			}
		}
		public void SetValueWithoutCallbacks(T value)
		{
			PropertyValue = value;
		}
		public static implicit operator T (BoundProperty<T> property)
		{
			return property.PropertyValue;
		}
		public BoundProperty(){}

		public BoundProperty(T initialValue){ PropertyValue = initialValue;}
	}
	[System.Serializable]
	public class BoundInt : BoundProperty<int>{
		public BoundInt(){}
		public BoundInt(int initalValue) : base(initalValue){}
	}
	[System.Serializable]
	public class BoundFloat : BoundProperty<float>{
		public BoundFloat(){}
		public BoundFloat(float initalValue) : base(initalValue){}
	}
	[System.Serializable]
	public class BoundString : BoundProperty<string>{
		public BoundString(){}
		public BoundString(string initalValue) : base(initalValue){}
	}
	[System.Serializable]
	public class BoundBool : BoundProperty<bool>{
		public BoundBool(){}
		public BoundBool(bool initalValue) : base(initalValue){}
	}
}
