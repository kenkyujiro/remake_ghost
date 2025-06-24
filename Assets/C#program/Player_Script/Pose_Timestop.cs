using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pose_Timestop : MonoBehaviour
{
    public string pushKey = "x";
    bool pushFlag = false;
    public PouseMenu poseMenu;

    void Start()
    {
        GameObject poseMenuUi = GameObject.Find("UIManager");
        if (poseMenuUi == null ){
            Debug.Log("セット先が見つかりません。:UI");
        }
        poseMenu = poseMenuUi.GetComponent<PouseMenu>();//poseMenu.関数()でいける
    }

    void Update()
    {
        if (Input.GetKey(pushKey))
        {
            if(pushFlag == false)
            {
                pushFlag = true;
                ApplicationPause();
            }
        }
        else
        {
            pushFlag = false;
        }
    }

    public void ApplicationPause()
    {
        if(Time.timeScale != 0)
        {
            poseMenu.PouseShow();
            PushSound.Instance.S_Pose();
            Time.timeScale = 0;
        }
        else
        {
            poseMenu.PouseClose();
            PushSound.Instance.S_PoseCancel();
            Time.timeScale = 1.0f;
        }
    }
}
