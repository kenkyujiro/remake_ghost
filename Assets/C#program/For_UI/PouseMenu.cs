using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouseMenu: MonoBehaviour
{
    public GameObject Pouse_PanelUI; //�E�C���h�E�̊Ǘ�
    public PouseManager pousemanage; //�����ł�getcomponent���g���Ȃ�

    private void Start()
    {
        Pouse_PanelUI.SetActive(false);
        pousemanage = GetComponent<PouseManager>();
    }

    public void PouseShow()
    {
        Pouse_PanelUI.SetActive(true);
        //�ԍ��ɂ���ďo�͂���y�[�W���Ⴄ���ߎQ�Ƃ��Ă���
        if(pousemanage.PageNumber == 1)
        {
            pousemanage.Page1Show();
        }
        else 
        {
            pousemanage.Page2Show();
        }
    }

    public void PouseClose()
    {
        Pouse_PanelUI.SetActive(false);
    } 
}

