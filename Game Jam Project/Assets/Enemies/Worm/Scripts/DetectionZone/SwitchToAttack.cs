using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToAttack : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<WormBehaviorSetter>() != null)
		{
			collision.gameObject.GetComponent<WormBehaviorSetter>().SetBehaviorRangeAttack();
		}
	}
}
