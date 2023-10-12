using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviorSetter setter;

	private void Awake()
	{
		setter = GetComponent<PlayerBehaviorSetter>(); 
	}

	void Update()
    {
		if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
			setter.SetBehaviorRuning();

		if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
			setter.SetBehaviorIdle();

		if (Input.GetKeyDown(KeyCode.K))
			setter.SetbehaviorMeleeAttack();
		
		if (Input.GetKeyDown(KeyCode.J) && StaminaBar.canDash)
			setter.SetbehaviorDash();
	}

}
