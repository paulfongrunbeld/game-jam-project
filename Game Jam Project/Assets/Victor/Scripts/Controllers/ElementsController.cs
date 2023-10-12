using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
	[SerializeField] private PlayerElementSetter setter;

	private void Awake() => setter = GetComponent<PlayerElementSetter>();
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			setter.SetElementDefault();

		if (Input.GetKeyDown(KeyCode.Alpha2))
			setter.SetElementAir();

		if (Input.GetKeyDown(KeyCode.Alpha3))
			setter.SetElementEarth();

		if (Input.GetKeyDown(KeyCode.Alpha4))
			setter.SetElementFire();

		if (Input.GetKeyDown(KeyCode.Alpha5))
			setter.SetElementWater();
	}
}
