using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
	public Transform rightHand;
	public Transform rightForeArm;
	public Transform rightArm;
	public Transform spine;
	public float condtionAngle = 40f;
	public Vector3 eulerAngle;
	public Vector3 angularSpeed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Vector3.Angle(rightForeArm.right*-1f, spine.forward) < condtionAngle && Vector3.Angle(rightArm.right*-1f, spine.forward) < condtionAngle)
		{
			transform.localEulerAngles = eulerAngle;
		}
		else
		{
			transform.Rotate(angularSpeed * Time.deltaTime);
		} 
    }
}
