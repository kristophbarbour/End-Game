using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour
{

	private float h;
	private float v;

	private float mx;
	private float my;

	private CharacterController cc;
	private Animator anim;
	
	private Vector3 moveDirection;
	private Vector3 targetDirection;

	[SerializeField]
	private float
		moveSpeed = 5f;
	[SerializeField]
	private float
		turnSpeed = 5f;
	[SerializeField]
	private float
		jumpHeight = 8f;
	[SerializeField]
	private float
		gravity = 20f;

	private float vSpeed = 0f;

	// Use this for initialization
	void Awake ()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per Pysics update
	void FixedUpdate ()
	{
		// Get movement input
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		// Get mouse input
		mx = Input.GetAxis ("Mouse X");
		my = Input.GetAxis ("Mouse Y");

		// Get Characters forward position
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		forward.y = 0;
		// Get Characters right position
		Vector3 right = transform.TransformDirection (Vector3.right);

		// Check for Jumping and apply gravity
		if (cc.isGrounded) {
			vSpeed = 0f;
			if (Input.GetButtonDown ("Jump")) {
				vSpeed = jumpHeight;
			}
		}
		
		// Move Character
		targetDirection = (h * right) + (v * forward); // Convert to int
		moveDirection = targetDirection.normalized * moveSpeed;
		// Add jumping
		vSpeed -= gravity * Time.deltaTime;
		moveDirection.y = vSpeed;
		// Move Character if there is input
		if (!Idle ()) {
			cc.Move (moveDirection * Time.deltaTime);
		}

		RotateCharacter ();

	}

	public bool Idle ()
	{
		return Input.GetAxisRaw ("Horizontal") == 0 && Input.GetAxisRaw ("Vertical") == 0 && vSpeed == 0;
	}

	void RotateCharacter ()
	{
		Cursor.lockState = CursorLockMode.Locked;

		float rotY = 0f;
		rotY += mx * turnSpeed;

		transform.Rotate (0, rotY, 0);


	}
}
