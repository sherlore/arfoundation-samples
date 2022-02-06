using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
	public Transform rightHand;
	public Transform spine;
	public float spinAngle = 80f;
	public Vector3 eulerAngle;
	public Vector3 angularSpeed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(rightHand.right*-1, spine.up) < spinAngle)
		{
			transform.Rotate(angularSpeed * Time.deltaTime);
		}
		else
		{
			// transform.localRotation = Quaternion.identity;
			transform.localEulerAngles = eulerAngle;
		}
    }
}
