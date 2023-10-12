using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform target;
    public  static Transform player;// ������ �� ������, �� ������� ������ ������
    public float smoothSpeed = 5.0f; // �������� ���������� ������
    public Vector3 offset = new Vector3(0, 0, -10); // �������� ������ ������������ ����

	private void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = player;
	}

	void LateUpdate()
    {
        if (target == null)
        {
            return; // ���� ���� �� ������, �� ������ ������
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
