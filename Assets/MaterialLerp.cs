using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialLerp : MonoBehaviour
{
	public Material mat;
	public string propertyName;
	private int propertyId;
	
	public float startValue;
	public float endValue;
	public float lerpDelayTime;
	public float lerpLength;
	private float lerpStartTime;
	
    void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
    }
	
	public void StartVFX()
	{
		mat.SetFloat(propertyId, startValue);
        lerpStartTime = Time.time;
		
		StartCoroutine( VFX() );
	}

    // Update is called once per frame
    /*void Update()
    {
		if(Time.time - lerpStartTime - lerpDelayTime < lerpLength + 3f)
		{			
			mat.SetFloat(propertyId, Mathf.Lerp(startValue, endValue, (Time.time - lerpStartTime - lerpDelayTime) / lerpLength ) );
		}
    }*/
	
	IEnumerator VFX()
	{
		while(Time.time - lerpStartTime - lerpDelayTime < lerpLength)
		{
			mat.SetFloat(propertyId, Mathf.Lerp(startValue, endValue, (Time.time - lerpStartTime - lerpDelayTime) / lerpLength ) );
			yield return null;
		}
		
		mat.SetFloat(propertyId, endValue );
	}
}
