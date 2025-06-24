using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_Shot_Navmesh : MonoBehaviour
{
    //�V���A���C�Y�c�v���n�u���g�����߂ɍs���o�C�g��ϊ�
    //�C���X�y�N�^�\����access(����)�������Ƃ��Ɏg��
    //�������Aprivate���g���邽�ߑ��̃N���X����̏���������h��
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 1.0f;
    private float time = 2.0f;

    void Start()
    {
        //�C���X�y�N�^�[�Őݒ肳��Ă��Ȃ��ꍇ�̂ݎ擾
        if (player == null) 
        {
            player = GameObject.FindWithTag("player");
            if (player == null)
            {
                Debug.LogError("Forever_Shot_Navmesh: �V�[������ 'Player' �^�O�̂����I�u�W�F�N�g��������܂���I");
            }
        }
    }


    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("player");
            // �܂��v���C���[��������Ȃ��ꍇ�͏������X�L�b�v
            if (player == null) return;
        }

        // ������player�����ɂ���
        transform.LookAt(player.transform);

        // ���Ԃ��t���[���P�ʂŊǗ�����
        time -= Time.deltaTime;
        if (time <= 0)
        {
            BallShot();
            time = 4f;
        }
    }

    void BallShot()
    {
        //object�����֐�(object��,�����ʒu,��������)
        Vector3 spawnPosition = transform.position + transform.forward * 1.0f; // �G�̑O��1m�ɒe�𐶐�
        //Vector3 spawnPosition = targetObject.transform.position + transform.forward * 1.0f;
        GameObject shotObj = Instantiate(ball, spawnPosition, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
    }
}