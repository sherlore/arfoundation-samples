using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TOS.Tool;

public class MachineGun : MonoBehaviour
{
	public ObjectPoolSystem objectPoolSystem;
	public float radius;
	public float lastFireTime;
	public float firePeriod;
	
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time - lastFireTime > firePeriod)
		{
			lastFireTime = Time.time;
			
			Fire();
		}
    }
	
	void Fire()
	{
		GameObject obj = objectPoolSystem.GetPooledInstance(null, false);
		Vector3 pos = transform.position + Random.insideUnitSphere * radius;
		obj.transform.position = pos;
		// obj.transform.localRotation = transform.localRotation;
		obj.transform.LookAt(pos + transform.forward * 1000f);
		
		obj.SetActive(true);
	}
}
