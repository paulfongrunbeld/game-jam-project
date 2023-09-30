using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> staminaPoints;
    [SerializeField] private GameObject numberToRemove;
    public static bool canDash = true;
	private void Awake() => numberToRemove = staminaPoints[staminaPoints.Count - 1];
	private void Start() => DashPlayerBehavior.onDash += WasteStamina;
	
	public void WasteStamina()
    {
        numberToRemove.SetActive(false);
        int indexToRemove = staminaPoints.IndexOf(numberToRemove);
        if (indexToRemove > 0)
            numberToRemove = staminaPoints[indexToRemove - 1];
        else canDash = false;
    }
}
