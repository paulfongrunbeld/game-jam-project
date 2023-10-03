using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWormBehavior : BaseBehavior
{
	public override void Exit()
	{
		this.enabled = false;
	}

	
}
