using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public static Vector3 targetPosition = new Vector3(0, 0, -10); // Целевая позиция камеры
    public static float targetSize = 5.0f; // Целевой размер камеры
    public float duration = 0.5f;

    [SerializeField] private Camera mainCamera;

    private void Start()
    {
        BattleTriger1.onTouch += SetCameraPositionAndSize1;
        EnemyHitHandler.onKill += SetCameraPositionAndSize2;
    }

    public void SetCameraPositionAndSize1()
    {
        transform.parent = null;
        mainCamera.transform.DOMove(targetPosition, duration);
        mainCamera.DOOrthoSize(targetSize, duration);

    }

    public void SetCameraPositionAndSize2()
    {
        CameraFollow.target = CameraFollow.player;
        mainCamera.transform.DOMove(CameraFollow.player.position, duration);
        mainCamera.DOOrthoSize(5f, duration);

    }
}
