using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP_Controller : MonoBehaviour
{
    int maxHp = 25;
    int currentHp;
    //�X���C�_�[�̎擾
    public Slider slider;

    void Start()
    {
        slider.value = 1;  //���^���ɂ���
        currentHp = maxHp; //�}�b�N�X�𔽉f
        Debug.Log("Start currentHp : " + currentHp);
    }

    public void OnDamage()
    {
        currentHp = currentHp - 1;
        //�ő�HP�ɂ����錻�݂�HP��Slider�ɔ��f�B
        //int���m�̊���Z�͏����_�ȉ���0�ɂȂ�̂ŁA
        //float�̕ϐ��Ƃ��ĐU���킹��B
        slider.value = (float)currentHp / (float)maxHp; ;
        Debug.Log("slider.value : " + slider.value);
    }
}
