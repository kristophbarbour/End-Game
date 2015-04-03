using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

	[SerializeField]
	private float
		sensitivityX = 15F;
	[SerializeField]
	private float
		sensitivityY = 15F;

	[SerializeField]
	private float
		minimumY = -60F;
	[SerializeField]
	private float
		maximumY = 20F;

	float rotationX = 0F;
	float rotationY = 0F;

	Quaternion originalRotation;

	void Update ()
	{
		rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
		rotationY = ClampAngle (rotationY, minimumY, maximumY);
		
		Quaternion yQuaternion = Quaternion.AxisAngle (Vector3.left, Mathf.Deg2Rad * rotationY);
		transform.localRotation = originalRotation * yQuaternion;
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody> ())
			GetComponent<Rigidbody> ().freezeRotation = true;
		originalRotation = transform.localRotation;
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
