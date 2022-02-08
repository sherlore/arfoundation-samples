using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
	public Transform head;
	public Transform rightHand;
	public Transform rightForeArm;
	public Transform rightArm;
	public Transform spine;
	public Transform cam;
	public float condtionAngle = 40f;
	public 
	
	void OnEnable()
	{
		if(cam == null)
		{
			cam = Camera.main.transform;
		}
	}
	
	void Update()
	{
		if(Vector3.Angle(rightForeArm.right*-1f, spine.right) < condtionAngle && Vector3.Angle(rightArm.right*-1f, spine.right) < condtionAngle)
		{
			Quaternion rotation = Quaternion.Euler(0, -90f, 0) * Quaternion.LookRotation(cam.position-head.position, Vector3.up);
			head.rotation = rotation;
			// head.LookAt(cam);
		}
		else
		{
			// head.LookAt(spine.position + rightForeArm.right*-100f);
			Quaternion rotation = Quaternion.Euler(0, -90f, 0) * Quaternion.LookRotation(rightForeArm.right*-100f, Vector3.up);
			head.rotation = rotation;
			
		}
	}
}
