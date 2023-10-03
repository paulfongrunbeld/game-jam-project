using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWormBehavior : BaseBehavior
{

	[SerializeField] private WalkWormBehavior walk;
	[SerializeField] private WormBehaviorSetter setter;

	[SerializeField] private GameObject leftAttackPos;
	[SerializeField] private GameObject rightAttackPos;

	[SerializeField] private SpriteRenderer sr;


	private void Awake()
	{
		setter = GetComponentInParent<WormBehaviorSetter>();

		leftAttackPos = GameObject.Find("LeftAttackZone");
		rightAttackPos = GameObject.Find("RightAttackZone");

		leftAttackPos.SetActive(false);
		rightAttackPos.SetActive(false);

		sr = GetComponent<SpriteRenderer>();

	}
	public override void Exit()
	{
		this.enabled = false;
	}

	public void SetAttackZone()
	{
		if (sr.flipX) leftAttackPos.SetActive(true);
		else rightAttackPos.SetActive(true);
	}

	public void DisableAttackZone()
	{
		leftAttackPos.SetActive(false);
		rightAttackPos.SetActive(false);
	}
	

}
