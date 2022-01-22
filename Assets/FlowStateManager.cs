using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStateManager : MonoBehaviour
{
	public FlowState flowState;
	
    public void StartFlow()
    {
        flowState.StartFlow();
    }
	
    public void StopFlow()
    {
        flowState.StopFlow();
    }
}
