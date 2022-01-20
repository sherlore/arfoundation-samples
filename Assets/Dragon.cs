using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
	public Transform head;
    public Transform directionTarget;
	
	void Update()
	{
		head.LookAt(directionTarget.position + directionTarget.forward * 100f);
	}
}
