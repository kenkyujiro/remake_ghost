using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PouseMenu: MonoBehaviour
{
    public GameObject Pouse_PanelUI; //ウインドウの管理
    public PouseManager pousemanage; //ここではgetcomponentが使えない

    private void Start()
    {
        Pouse_PanelUI.SetActive(false);
        pousemanage = GetComponent<PouseManager>();
    }

    public void PouseShow()
    {
        Pouse_PanelUI.SetActive(true);
        //番号によって出力するページが違うため参照している
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

