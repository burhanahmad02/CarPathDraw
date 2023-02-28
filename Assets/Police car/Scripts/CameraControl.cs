// Type: CameraControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1E47F766-D0C3-4397-B2A2-2A36958C713B
// Assembly location: C:\Users\Niv\Downloads\Unity ReverseEng\disunity_v0.3.1\2dvechicle\Assembly-CSharp.dll

using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public float dampTime;
	public Vector3 offset;
	private Vector3 velocity;
	public Transform target;
	
	private void FixedUpdate()
	{
		if (target == null)
			return;

		transform.position = Vector3.SmoothDamp(transform.position, (transform.position + (target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, GetComponent<Camera>().WorldToViewportPoint(target.transform.position).z)))) - offset, ref velocity, dampTime);
	}
}
