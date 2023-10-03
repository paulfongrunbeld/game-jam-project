using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WalkWormBehavior : BaseBehavior
{
	[SerializeField] private Transform target;
	[SerializeField] private float speed;
	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private SpriteRenderer sr;
	public List<GameObject> attackPositions;
	[SerializeField] public Vector2 currentAttackPos;
	private void Awake()
	{
		speed = 1f;
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		
		attackPositions = new List<GameObject>();
	}
	
	public Transform Target 
	{
		set { target = value; }
	}

	public override void Update()
	{
		transform.position += ((Vector3)currentAttackPos - transform.position).normalized * speed * Time.deltaTime;
		SetRotation();
		SetAttackPos();

	}

	private void SetRotation()
	{
		if ((target.position.x - transform.position.x) < 0) sr.flipX = true;
		else if ((target.position.x - transform.position.x) > 0) sr.flipX = false;
	}

	public void SetAttackPos()
	{
		if (Vector3.Distance(attackPositions[0].transform.position, transform.position) > Vector3.Distance(attackPositions[1].transform.position, transform.position))
		{
			currentAttackPos = attackPositions[1].transform.position;
		}
		else currentAttackPos = attackPositions[0].transform.position;

	}

	public override void Exit()
	{
		this.enabled = false;
	}
}
