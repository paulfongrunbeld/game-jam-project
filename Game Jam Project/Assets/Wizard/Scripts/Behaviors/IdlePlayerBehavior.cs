using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerBehavior : BaseBehavior
{
	[SerializeField] private PlayerMovement movement;

	private void Awake()
	{
		movement = GetComponent<PlayerMovement>();
	}
	public override void Enter()
	{
		movement.enabled = false;
	}
	public override void Exit()
	{
		this.enabled = false;
		movement.enabled = true;
	}
}
