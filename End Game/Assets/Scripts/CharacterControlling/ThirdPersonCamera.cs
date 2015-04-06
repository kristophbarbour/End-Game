using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{


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
	
	//New Cam Rotation stuff
	
	public Transform player;
	public Vector3 pivotOffset = new Vector3 (0.0f, 1.0f, 0.0f);
	public Vector3 camOffset = new Vector3 (0.0f, 0.7f, -3.0f);
	private Vector3 relCameraPos;
	private float relCameraPosMag;
	private Vector3 smoothPivotOffset;
	private Vector3 smoothCamOffset;
	
	private Transform cam;
	public float smooth = 10f;
	
	void Update ()
	{
	
	
		float targetRotationAngle = player.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		
		
		rotationX = Mathf.LerpAngle (currentRotationAngle, targetRotationAngle, 10f * Time.deltaTime);
		
		
		rotationY += Mathf.Clamp (Input.GetAxis ("Mouse Y"), -1, 1) * sensitivityY;
		rotationY = ClampAngle (rotationY, minimumY, maximumY);
		Quaternion aimRotation = Quaternion.Euler (-rotationY, rotationX, 0);
		cam.rotation = aimRotation;
		
		
		
	
		
		cam.position = player.position + smoothPivotOffset + aimRotation * smoothCamOffset;
		
		
		
	}
	
	void Start ()
	{
		smoothPivotOffset = pivotOffset;
		smoothCamOffset = camOffset;
		cam = transform;
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
