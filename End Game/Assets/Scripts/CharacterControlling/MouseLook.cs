using System;
using UnityEngine;

public class MouseLook:MonoBehaviour
{
	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;

	void Start ()
	{

	}

	void Update ()
	{
		Transform camera = this.transform;

		float xRot = Input.GetAxis ("Mouse Y") * YSensitivity;
		xRot = ClampAngle (xRot, MinimumX, MaximumX);

		transform.Rotate (-xRot, 0f, 0f);
	}
	
	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}
	
}
