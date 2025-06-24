using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision_DestoryMe_BOSS : MonoBehaviour
{
    public string tagName;
    public string sceneName = "";
    public GameObject BossHPController;

    public int Boss_Life = 3;

    private void OnCollisionEnter(Collision collision)
    {
        //�Ԃ��������ɖړI�̃^�O�l�[���������Ă��邩�ǂ���
        if (collision.gameObject.tag == tagName)
        {
            Debug.Log("�ڕW�̃^�O�ƏՓ˂��܂����B�^�O��: " + collision.gameObject.tag); // �^�O�����������m�F
            //�e�q�֌W�ł���Ƃ��ŏ�����ύX����
            if (Boss_Life <= 1 && transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            //�{�X�̗̑͂�1�ȉ��ł���ꍇ�͌��j�A�Q�[���N���A�V�[���ɑJ��
            else if(Boss_Life <= 1)
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                if (sceneName != "")  // �V�[����������΁A�؂芷����
                {
                    SceneManager.LoadScene(sceneName);
                    BGMManager.Instance.BGM_Stop();
                }
                else
                {   // �V�[�������Ȃ���΁A���̃V�[���֐؂芷����
                    int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    if (nextIndex < SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene(nextIndex);
                    }
                    else
                    {   // ���̃V�[�����Ȃ���΁A�ŏ��̃V�[���ɐ؂芷����
                        SceneManager.LoadScene(0);
                    }
                }
            }
            else 
            {
                Boss_Life -= 1;
                BossHPController.GetComponent<Boss_HP_Controller>().OnDamage();
                Destroy(collision.gameObject);
            }
        }
        else
        {
        }
    }

    public void DestroySelf()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}