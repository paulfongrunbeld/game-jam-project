using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchToWalkTrigger : MonoBehaviour
{
	[SerializeField] private WormBehaviorSetter setter;
	[SerializeField] private WalkWormBehavior walkBehavior;

	private void Awake()
	{
		setter = GetComponentInParent<WormBehaviorSetter>();
		walkBehavior = GetComponentInParent<WalkWormBehavior>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<PlayerMovement>() != null)
		{
			setter.SetBehaviorWalk();
			walkBehavior.Target = collision.gameObject.transform;
			GetChildObjects(collision.gameObject.transform);
			Destroy(gameObject);
		}
	}

	void GetChildObjects(Transform parent)
	{
		foreach (Transform child in parent)
		{
			// Добавить дочерний объект в список
			walkBehavior.attackPositions.Add(child.gameObject);

			// Рекурсивно вызвать эту же функцию для всех дочерних объектов текущего объекта
			GetChildObjects(child);
		}
	}
}
