using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;                           // �v���C���[��Transform(�ʒu)
    public CinemachineVirtualCamera virtualCamera;     // Virtual Camera���̂���
    public Vector3 backOffset = new Vector3(0, 2, -4); // �w�ʃI�t�Z�b�g(�����Ŕw�ʂ��`����)

    private bool isBehind = false;


    void Update()
    {
        if(Time.timeScale != 0)//�|�[�Y��ԂłȂ��Ƃ��A
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

            // �ꎞ�I�ɒǏ]������
            virtualCamera.Follow = null;

            // �v���C���[�̈ʒu�Ɖ�]�Ɋ�Â��ăJ������w��ֈړ�
            Vector3 newCameraPosition = player.position + player.rotation * backOffset;

            // �J�����ʒu�Ɖ�]�𑦎��X�V
            virtualCamera.transform.position = newCameraPosition;
            virtualCamera.transform.LookAt(player);

            Debug.Log("�J�������w��ɉ��܂���");

        }
    }

    void ResetCameraFollow()
    {
        if (virtualCamera != null)
        {
            // ���̒Ǐ]�ݒ�ɖ߂�
            virtualCamera.Follow = player;
            Debug.Log("�J�����Ǐ]�ɖ߂�܂���");
        }
    }

}