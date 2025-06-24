using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject Toggle_PanelUI;

    // Start is called before the first frame update
    void Start()
    {
        Toggle_PanelUI.SetActive(false);
    }

    public void Option_Show() 
    {
        Toggle_PanelUI.SetActive(true);
    }

    public void Option_Close()
    {
        Toggle_PanelUI.SetActive(false);
    }
}
