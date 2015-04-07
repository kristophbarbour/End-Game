using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

public class HoldWeapon : MonoBehaviour
{
	
	[SerializeField]
	FullBodyBipedIK
		ik;
	[SerializeField]
	Transform
		aimTarget;
	[SerializeField]
	Transform
		leftHandTarget, rightHandTarget;
	
	
	void LateUpdate ()
	{
		ik.solver.leftHandEffector.position = leftHandTarget.position;
		ik.solver.leftHandEffector.rotation = leftHandTarget.rotation;
		ik.solver.leftHandEffector.positionWeight = 1f;
		ik.solver.leftHandEffector.rotationWeight = 1f;
		
		ik.solver.rightHandEffector.position = rightHandTarget.position;
		ik.solver.rightHandEffector.rotation = rightHandTarget.rotation;
		ik.solver.rightHandEffector.positionWeight = 1f;
		ik.solver.rightHandEffector.rotationWeight = 1f;
		
		transform.LookAt (aimTarget.position);
	}
}
