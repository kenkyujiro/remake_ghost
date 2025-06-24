using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public float attackRange = 5f; // Ray�̋���
    public LayerMask enemyLayer; // �G�̃��C���[���w��

    void Update()
    {
        if(Time.timeScale != 0)//�|�[�Y��ԂłȂ��Ƃ��A
        {
            //V�������ƒ��ڍU��
            //���x���U���\(�N�[���^�C�������ׂ����c)
            if (Input.GetKeyDown(KeyCode.V))
            {
                Attack();
                PushSound.Instance.S_DirectAttack();
            }
        }
    }

    void Attack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // �v���C���[�̑O����Ray�𓊂��A�G���C���[�ɓ����邩�ǂ������`�F�b�N
        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            // Ray�����������I�u�W�F�N�g��Enemy�^�O�������Ă��邩�m�F
            if (hit.collider.CompareTag("eliminiate"))
            {
                // �G�̍폜���\�b�h���Ăяo��
                hit.collider.GetComponent<OnCollision_DestoryMe>().DestroySelf();
            }
        }
    }
}
