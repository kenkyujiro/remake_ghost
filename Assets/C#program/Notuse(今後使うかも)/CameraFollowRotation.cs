using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRotation : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public Vector3 offset = new Vector3(0, 5, -7);  // �J�����̑��Έʒu
    public float rotationSmoothTime = 0.1f;  // ��]�̃X���[�W���O

    private float currentYAngle;
    private float yAngleVelocity;

    void LateUpdate()
    {
        if (player == null) return;

        // �v���C���[�̉�]Y���擾
        float targetYAngle = player.eulerAngles.y;

        // Y��]���X���[�Y�ɒǏ]
        currentYAngle = Mathf.SmoothDampAngle(currentYAngle, targetYAngle, ref yAngleVelocity, rotationSmoothTime);

        // �v���C���[�̈ʒu + �I�t�Z�b�g����]�ɍ��킹�čX�V
        Quaternion rotation = Quaternion.Euler(0, currentYAngle, 0);
        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(player.position + Vector3.up * 1.5f);  // ������������i�D�݂ɉ����āj
    }
}
