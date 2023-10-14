using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class BattleTriger1 : MonoBehaviour
{
	public GameObject target1; // ������� ������� ������
	public float targetSize1 = 5.75f; // ������� ������ ������

	public static Action onTouch;

	public GameObject leftfirewall;
	public GameObject rightfirewall;

	public MusicManager musicManager;

	public static Action music;
	

	private void Awake()
	{
		musicManager = GameObject.FindGameObjectWithTag("music").GetComponent<MusicManager>();
		EnemyHitHandler.onKill += KillFire;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		music?.Invoke();
		
		if (collision.gameObject.tag.Equals("Player"))
		{
			leftfirewall.SetActive(true);
			rightfirewall.SetActive(true);

			musicManager.audio.Stop();
			musicManager.Combat();

			CameraController.targetPosition = target1.transform.position;
			CameraController.targetSize = targetSize1;
			CameraFollow.target = null;
			onTouch?.Invoke();
			Destroy(this.gameObject);
		}
	}

	public void KillFire()
	{
		leftfirewall.SetActive(false);
		rightfirewall.SetActive(false);

	}



	//public GameObject target2; // ������� ������� ������
	//public float targetSize2 = 5.75f; // ������� ������ ������

	//public GameObject targetWater; // ������� ������� ������
	//public float targetSizeWater = 5.75f; // ������� ������ ������

	// public GameObject targetFire; // ������� ������� ������
	//public float targetSizeFire = 5.75f; // ������� ������ ������

	//public GameObject targetEarth; // ������� ������� ������
	//public float targetSizeEarth = 5.75f; // ������� ������ ������

	//public GameObject targetAir; // ������� ������� ������
	//public float targetSizeAir = 5.75f; // ������� ������ ������




}
