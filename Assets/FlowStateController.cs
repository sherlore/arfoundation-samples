using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStateController : MonoBehaviour
{
	public enum Direction
	{
		Forward,
		Left,
		Right,
		Up
	}
	
	public enum Hand
	{
		Left,
		Right
	}
	
	[System.Serializable]
	public class FlowCondition
	{
		public FlowState flowState;
		public Direction direction;
		public Hand startHand;		
		public Hand stopHand;		
	}
	
	public FlowCondition[] flowConditions;
	
	public Transform spine;
	public Transform leftHand;
	public Transform leftElbow;
	public Transform leftShoulder;
	public Transform rightHand;
	public Transform rightElbow;
	public Transform rightShoulder;
	
	public float condtionAngle = 30f;
	public float condtionDistance = 0.3f;
	
	public FlowState nowState;
	public FlowCondition nowCondition;
	public float conditionStartMatchTime;
	public float condtionStartPeriod;
	
	public bool stoppingState;
	public float conditionStopMatchTime;
	public float condtionStopPeriod;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nowState == null)
		{
			if(nowCondition == null)
			{
				for(int i=0; i<flowConditions.Length; i++)
				{
					if(!MatchStopCondition(flowConditions[i]) && MatchStartCondition(flowConditions[i]))
					{
						nowCondition = flowConditions[i];
						conditionStartMatchTime = Time.time;
						break;
					}
				}
			}
			else
			{
				if(MatchStartCondition(nowCondition))
				{
					if(Time.time - conditionStartMatchTime > condtionStartPeriod)
					{
						nowState = nowCondition.flowState;
						nowState.StartFlow();
					}
				}
				else
				{
					nowCondition = null;
				}
			}
		}
		else
		{
			if(stoppingState)
			{
				if(MatchStopCondition(nowCondition))
				{
					if(Time.time - 	conditionStopMatchTime > condtionStopPeriod)
					{
						nowState.StopFlow();
						stoppingState = false;
						
						nowState = null;
						nowCondition = null;
					}
				}
				else
				{
					stoppingState = false;
				}
			}
			else
			{
				if(MatchStopCondition(nowCondition))
				{
					stoppingState = true;
					conditionStopMatchTime = Time.time;
				}
			}
		}
    }
	
	public bool MatchStartCondition(FlowCondition condtion)
	{
		if(condtion.startHand == Hand.Left)
		{
			if(condtion.direction == Direction.Forward)
			{
				if(Vector3.Angle(leftElbow.right, leftShoulder.right) < condtionAngle && Vector3.Angle(leftElbow.right, spine.up) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Left)
			{
				if(Vector3.Angle(leftElbow.right, leftShoulder.right) < condtionAngle && Vector3.Angle(leftElbow.right, spine.forward*-1f) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Right)
			{
				if(Vector3.Angle(leftElbow.right, leftShoulder.right) < condtionAngle && Vector3.Angle(leftElbow.right, spine.forward) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Up)
			{
				if(Vector3.Angle(leftElbow.right, leftShoulder.right) < condtionAngle && Vector3.Angle(leftElbow.right, spine.right) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		else
		{
			if(condtion.direction == Direction.Forward)
			{
				if(Vector3.Angle(rightElbow.right, rightShoulder.right) < condtionAngle && Vector3.Angle(rightElbow.right*-1f, spine.up) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Left)
			{
				if(Vector3.Angle(rightElbow.right, rightShoulder.right) < condtionAngle && Vector3.Angle(rightElbow.right, spine.forward) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Right)
			{
				if(Vector3.Angle(rightElbow.right, rightShoulder.right) < condtionAngle && Vector3.Angle(rightElbow.right*-1f, spine.forward) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else if(condtion.direction == Direction.Up)
			{
				if(Vector3.Angle(rightElbow.right, rightShoulder.right) < condtionAngle && Vector3.Angle(rightElbow.right*-1f, spine.right) < condtionAngle)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
	
	public bool MatchStopCondition(FlowCondition condtion)
	{
		if(condtion.stopHand == Hand.Left)
		{
			if(Vector3.Distance(leftHand.position, spine.position) < condtionDistance)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			if(Vector3.Distance(rightHand.position, spine.position) < condtionDistance)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
