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

                //アニメーションへの参照はゲームオブジェクト自体に参照させる
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
