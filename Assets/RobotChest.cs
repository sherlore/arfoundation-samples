using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotChest : MonoBehaviour
{
	public Animation anim;
	
    public void PlayAnim(string animName)
    {
        anim.Play(animName);
    }
}
