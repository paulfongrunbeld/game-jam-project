using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetHit : MonoBehaviour
{
	[SerializeField] private PlayerBehaviorSetter setter;

	[SerializeField] private HealthBar hp;

	private void Awake()
	{
		setter = GetComponent<PlayerBehaviorSetter>();
		hp = GameObject.FindGameObjectWithTag("HPBar").GetComponent<HealthBar>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("FireWorm"))
		{
			hp.GetDamage();
			setter.SetbehaviorHit();
		}
	}

	
}
