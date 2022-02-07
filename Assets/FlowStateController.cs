using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowStateController : MonoBehaviour
{
	public enum Direction
	{
		Flat,
		Up
	}
	
	public enum Hand
	{
		Left,
		Right,
		Both
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
	
	public Transform head;
	public Transform spine;
	public Transform leftHand;
	public Transform leftForeArm;
	public Transform leftArm;
	public Transform rightHand;
	public Transform rightForeArm;
	public Transform rightArm;
	
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
						
						Handheld.Vibrate();
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
					Handheld.Vibrate();
				}
			}
		}
    }
	
	public bool MatchDirection(Vector3 forearmDir, Vector3 armDir, Vector3 targetDir)
	{
		if(Vector3.Angle(forearmDir, targetDir) < condtionAngle && Vector3.Angle(armDir, targetDir) < condtionAngle)
		{
			return true;
		}
		else
		{
			return false;
		} 
	}
	
	public bool MatchStartCondition(FlowCondition condtion)
	{
		if(condtion.startHand == Hand.Left)
		{
			if(condtion.direction == Direction.Flat)
			{
				if(MatchDirection(leftForeArm.right, leftArm.right, spine.forward*-1f) && !MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.forward))
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
				if(MatchDirection(leftForeArm.right, leftArm.right, spine.right) && !MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.right))
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
		else if(condtion.startHand == Hand.Right)
		{
			if(condtion.direction == Direction.Flat)
			{
				if(!MatchDirection(leftForeArm.right, leftArm.right, spine.forward*-1f) && MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.forward))
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
				if(!MatchDirection(leftForeArm.right, leftArm.right, spine.right) && MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.right))
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
			if(condtion.direction == Direction.Flat)
			{
				if(MatchDirection(leftForeArm.right, leftArm.right, spine.forward*-1f) && MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.forward))
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
				if(MatchDirection(leftForeArm.right, leftArm.right, spine.right) && MatchDirection(rightForeArm.right*-1f, rightArm.right*-1f, spine.right))
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
