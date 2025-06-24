using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRotation : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public Vector3 offset = new Vector3(0, 5, -7);  // カメラの相対位置
    public float rotationSmoothTime = 0.1f;  // 回転のスムージング

    private float currentYAngle;
    private float yAngleVelocity;

    void LateUpdate()
    {
        if (player == null) return;

        // プレイヤーの回転Yを取得
        float targetYAngle = player.eulerAngles.y;

        // Y回転をスムーズに追従
        currentYAngle = Mathf.SmoothDampAngle(currentYAngle, targetYAngle, ref yAngleVelocity, rotationSmoothTime);

        // プレイヤーの位置 + オフセットを回転に合わせて更新
        Quaternion rotation = Quaternion.Euler(0, currentYAngle, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f);  // 少し上を向く（好みに応じて）
    }
}
