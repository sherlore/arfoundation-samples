using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
	public Transform rightHand;
	public Transform rightShoulder;
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
		Vector3 dirRight = (rightHand.position-rightShoulder.position).normalized;
		
        // if(Vector3.Angle(rightHand.right*-1, spine.up) < spinAngle)
        if(Vector3.Angle(dirRight, spine.up) < spinAngle)
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
