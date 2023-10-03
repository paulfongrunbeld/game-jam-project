using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToWalkAfterAttack : MonoBehaviour
{
	[SerializeField] private WormBehaviorSetter setter;
	private void Awake()
	{
		setter = GetComponentInParent<WormBehaviorSetter>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>() != null)
		{
			setter.SetBehaviorWalk();
		}
	}
}
