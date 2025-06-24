using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// �V�[���؂�ւ��ɕK�v

// �Փ˂�����A�V�[����؂芷����
public class OnCollisionItemget : MonoBehaviour
{
    public string tagName_Heal;
    public string tagName_Bullet;
    public float heal = 1;
    [SerializeField] private HealthBarHUDTester healthTester;//�\����̃n�[�g�Ǘ�
    [SerializeField] private OnCollision_SwitchScene OnCollision_Guy;//���l��̃n�[�g�Ǘ�
    [SerializeField] private OnKeyPress_Throw OnKeyPress_Throw;//�v���C���[�e����s���Ă���

    private void OnCollisionEnter(Collision collision)
    {
        //�q�[���A�C�e���擾��
        if (collision.gameObject.tag == tagName_Heal)
        {
            if(OnCollision_Guy.Heart >= 5) 
            {
                Debug.Log("�������I");
                Debug.Log("�c��HP�F" + OnCollision_Guy.Heart);
                PushSound.Instance.S_Heal();
                Destroy(collision.gameObject);
            }
            else
            {
                OnCollision_Guy.Heart += 1;
                if(OnCollision_Guy.Heart > 5)
                {
                    OnCollision_Guy.Heart = 5;
                }
                healthTester.Heal(heal);
                Debug.Log("�񕜂���I");
                Debug.Log("�c��HP�F" + OnCollision_Guy.Heart);
                PushSound.Instance.S_Heal();
                Destroy(collision.gameObject);
            }
            
        }
        //�e��A�C�e���擾��
        else if(collision.gameObject.tag == tagName_Bullet)
        {
            if(OnKeyPress_Throw.rerode >= 10)
            {
                Debug.Log("�e��͂����ς��I");
                Debug.Log("�c��e���F" + OnKeyPress_Throw.rerode);
                PushSound.Instance.S_Rerode();
                Destroy(collision.gameObject);
            }
            else 
            {
                OnKeyPress_Throw.bullet();
                Debug.Log("�����[�h!");
                Debug.Log("�c��e���F" + OnKeyPress_Throw.rerode);
                PushSound.Instance.S_Rerode();
                Destroy(collision.gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

}