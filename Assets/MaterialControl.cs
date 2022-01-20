using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControl : MonoBehaviour
{
	public Material mat;
	public string propertyName;
	private int propertyId;
	
    void Awake()
    {
        propertyId = Shader.PropertyToID(propertyName);
    }
	
    public void SetFloat(float val)
    {        
		mat.SetFloat(propertyId, val);
    }
}
