namespace SimpleEasing
{
	
using UnityEngine;
using System;
using System.Collections;

	public static class VectorHelper
	{
		private static Vector2 _vector2;
		private static Vector3 _vector3;
		private static Quaternion _quaternion;
		private static Color _color;
		
		public static Vector2 EaseVector2(Func<float, float, float, float>easingFunction, Vector2 from, Vector2 to, float t){
			_vector2.x = easingFunction(from.x, to.x, t);
			_vector2.y = easingFunction(from.y, to.y, t);
		
			return _vector2;
		}
		public static Vector3 EaseVector3(Func<float, float, float, float>easingFunction, Vector3 from, Vector3 to, float t){
			_vector3.x = easingFunction(from.x, to.x, t);
			_vector3.y = easingFunction(from.y, to.y, t);
			_vector3.z = easingFunction(from.z, to.z, t);

			return _vector3;
		}
		public static Quaternion EaseQuaternion(Func<float, float, float, float>easingFunction, Quaternion from, Quaternion to, float t){
			_quaternion.x = easingFunction(from.x, to.x, t);
			_quaternion.y = easingFunction(from.y, to.y, t);
			_quaternion.z = easingFunction(from.z, to.z, t);
			_quaternion.w = easingFunction(from.w, to.w, t);

			return _quaternion;
		}
		public static Color EaseColor(Func<float, float, float, float>easingFunction, Color from, Color to, float t){
			_color.r = easingFunction(from.r, to.r, t);
			_color.g = easingFunction(from.g, to.g, t);
			_color.b = easingFunction(from.b, to.b, t);
			_color.a = easingFunction(from.a, to.a, t);

			return _color;
		}
	}
}
