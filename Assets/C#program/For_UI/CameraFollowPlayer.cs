using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;                           // プレイヤーのTransform(位置)
    public CinemachineVirtualCamera virtualCamera;     // Virtual Cameraそのもの
    public Vector3 backOffset = new Vector3(0, 2, -4); // 背面オフセット(ここで背面を定義する)

    private bool isBehind = false;


    void Update()
    {
        if(Time.timeScale != 0)//ポーズ状態でないとき、
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (isBehind)
                {
                    ResetCameraFollow();
                }
                else
                {
                    MoveCameraBehindPlayer();
                }
                isBehind = !isBehind;
            }
        }
    }

    void MoveCameraBehindPlayer()
    {
        if (player != null && virtualCamera != null)
        {

            // 一時的に追従を解除
            virtualCamera.Follow = null;

            // プレイヤーの位置と回転に基づいてカメラを背後へ移動
            Vector3 newCameraPosition = player.position + player.rotation * backOffset;

            // カメラ位置と回転を即時更新
            virtualCamera.transform.position = newCameraPosition;
            virtualCamera.transform.LookAt(player);

            Debug.Log("カメラが背後に回りました");

        }
    }

    void ResetCameraFollow()
    {
        if (virtualCamera != null)
        {
            // 元の追従設定に戻す
            virtualCamera.Follow = player;
            Debug.Log("カメラ追従に戻りました");
        }
    }

}