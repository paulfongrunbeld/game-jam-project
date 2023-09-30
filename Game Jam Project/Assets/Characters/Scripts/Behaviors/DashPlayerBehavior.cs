using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DashPlayerBehavior : BaseBehavior
{
	[SerializeField] private PlayerMovement movement;
	[SerializeField] private InputController controller;

	public static Action onDash;

	private void Awake()
	{
		movement = GetComponent<PlayerMovement>();
		controller = GetComponent<InputController>();
	}
	public override void Enter()
	{
		movement.Dash();
		movement.enabled = false;
		controller.enabled = false;
		onDash?.Invoke();
	}

	public override void Exit()
	{
		movement.enabled = true;
		movement.StopMove();
		controller.enabled = true;
		this.enabled = false;
	}


}
