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
	public Vector3 eulerSet;
	
	void OnEnable()
	{
		if(cam == null)
		{
			cam = Camera.main.transform;
		}
		
		eulerSet = new Vector3(PlayerPrefs.GetFloat("X", 0), PlayerPrefs.GetFloat("Y", 0), PlayerPrefs.GetFloat("Z", 0) );
	}
	
	void Update()
	{
		if(Vector3.Angle(rightForeArm.right*-1f, spine.right) < condtionAngle && Vector3.Angle(rightArm.right*-1f, spine.right) < condtionAngle)
		{
			Quaternion rotation = Quaternion.Euler(eulerSet) * Quaternion.LookRotation(cam.position-head.position, Vector3.up);
			head.rotation = rotation;
			// head.LookAt(cam);
		}
		else
		{
			// head.LookAt(spine.position + rightForeArm.right*-100f);
			Quaternion rotation = Quaternion.Euler(eulerSet) * Quaternion.LookRotation(rightForeArm.right*-100f, Vector3.up);
			head.rotation = rotation;
			
		}
	}
}
