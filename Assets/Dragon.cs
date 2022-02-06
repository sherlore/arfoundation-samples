using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
	public Transform head;
    public Transform directionTarget;
    public Transform hand;
    public Transform arm;
	
	void Update()
	{
		head.LookAt(directionTarget.position + (hand.position-arm.position) * 100f);
	}
}
