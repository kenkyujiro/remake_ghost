using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashTriggerAnimation : MonoBehaviour
{
    public string pushKey = "B";
    public string triggerName = "";

    bool pushFlag = false;

    void Update()
    {
        if (Input.GetKey(pushKey))
        {
            if (pushFlag == false)
            {
                pushFlag = true;

                //�A�j���[�V�����ւ̎Q�Ƃ̓Q�[���I�u�W�F�N�g���̂ɎQ�Ƃ�����
                Animator m_Animator = gameObject.GetComponent<Animator>();
                m_Animator.SetTrigger(triggerName);
            }
        }
        else
        {
            pushFlag = false;
        }
    }
}
