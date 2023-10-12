using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform target;
    public  static Transform player;// Ссылка на объект, за которым следит камера
    public float smoothSpeed = 5.0f; // Скорость следования камеры
    public Vector3 offset = new Vector3(0, 0, -10); // Смещение камеры относительно цели

	private void Awake()
	{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = player;
	}

	void LateUpdate()
    {
        if (target == null)
        {
            return; // Если цель не задана, не делаем ничего
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
