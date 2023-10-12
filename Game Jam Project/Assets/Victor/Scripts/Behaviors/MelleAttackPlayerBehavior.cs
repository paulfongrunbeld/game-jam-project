using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttackPlayerBehavior : BaseBehavior
{
	[SerializeField] private PlayerMovement movement;
	[SerializeField] private InputController controller;

	[SerializeField] private GameObject leftAttackZone;
	[SerializeField] private GameObject rightAttackZone;

	[SerializeField] private SpriteRenderer sr;



	private void Awake()
	{
		movement = GetComponent<PlayerMovement>();
		controller = GetComponent<InputController>();
		sr = GetComponent<SpriteRenderer>();
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

	public void SetAttackZone()
	{
		if (sr.flipX) leftAttackZone.SetActive(true);
		else rightAttackZone.SetActive(true);
	}

	public void AttackZoneOff()
	{
		rightAttackZone.SetActive(false);
		leftAttackZone.SetActive(false);
	}

}
