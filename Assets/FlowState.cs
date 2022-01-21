using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlowState : MonoBehaviour
{
	[System.Serializable]
	public class FlowUnit
	{
		public float delayTime;
		public UnityEvent triggerEvent;
	}
	
	public FlowUnit[] enterflow;
	public FlowUnit[] exitflow;
	private IEnumerator coroutine;
	
    public void StartFlow()
    {
        if(coroutine != null)
		{
			StopCoroutine(coroutine);	
		}
		
		coroutine = EnterFlowProcess();
		
		StartCoroutine(coroutine);	
    }
	
    public void StopFlow()
    {
        if(coroutine != null)
		{
			StopCoroutine(coroutine);	
		}
		
		coroutine = ExitFlowProcess();
		
		StartCoroutine(coroutine);	
    }

	
	IEnumerator EnterFlowProcess()
    {
		float enterTime = Time.time;
		
		for(int i=0; i<enterflow.Length; i++)
		{
			while(Time.time - enterTime < enterflow[i].delayTime)
			{
				yield return null;
			}
			
			enterflow[i].triggerEvent.Invoke();
		}
    }
	
	IEnumerator ExitFlowProcess()
    {
		float exitTime = Time.time;
		
		for(int i=0; i<exitflow.Length; i++)
		{
			while(Time.time - exitTime < exitflow[i].delayTime)
			{
				yield return null;
			}
			
			exitflow[i].triggerEvent.Invoke();
		}
    }
}
