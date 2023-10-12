using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerBehavior : BaseBehavior
{

	[SerializeField] private PlayerBehaviorSetter setter;

	[SerializeField] private PlayerMovement movement;
	[SerializeField] private InputController controller;

	private void Awake()
	{
		movement = GetComponent<PlayerMovement>();
		controller = GetComponent<InputController>();
		setter = GetComponent<PlayerBehaviorSetter>();
	}
	public override void Enter()
	{
		movement.enabled = false;
		controller.enabled = false;
	}
	public override void Exit()
	{
		movement.enabled = true;
		controller.enabled = true;

		this.enabled = false;
	}
}
