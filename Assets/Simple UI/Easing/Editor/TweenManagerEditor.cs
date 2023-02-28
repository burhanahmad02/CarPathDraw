namespace SimpleEasing.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CustomEditor(typeof(TweenManager), true)]
	public class TweenManagerEditor : Editor
	{

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			var targetScript = (TweenManager) target;

			GUILayout.Label("Tween Pool Size: " + Tween.PoolSize.ToString());
		}
	}
}