using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementSetter : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private Elements Element
    {
        get { return (Elements)anim.GetInteger("element"); }
        set { anim.SetInteger("element", (int)value); }
    }

	private void Awake()
	{
        anim = GetComponent<Animator>();
        SetElementDefault();
    }

	private enum Elements
    {
        Default,
        Air,
        Earth,
        Fire,
        Water
    }

    public void SetElementDefault() => Element = Elements.Default;
    public void SetElementAir() => Element = Elements.Air;
    public void SetElementEarth() => Element = Elements.Earth;
    public void SetElementFire() => Element = Elements.Fire;
    public void SetElementWater() => Element = Elements.Water;

}
