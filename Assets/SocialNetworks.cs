using UnityEngine;
using System.Collections;

public class SocialNetworks
{
	public static AndroidJavaClass pluginClass ;
	public static AndroidJavaObject jObject;

	public static void ShareURL(string title, string url)
	{
		pluginClass = new AndroidJavaClass("com.myplugin.test.ShareClass");
		jObject= pluginClass.CallStatic<AndroidJavaObject>("instance");
		jObject.Call("ShareOnClick", (title + "\n" + url));
	}
}
