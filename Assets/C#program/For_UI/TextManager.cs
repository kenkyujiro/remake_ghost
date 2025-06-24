using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject Page0UIObj; //ページごとの要素の管理
    public GameObject Page1UIObj;
    public GameObject Page2UIObj;
    public GameObject Page1Obj;   //オブジェクト(お化けなど)の管理
    public GameObject Page2Obj;
    public GameObject Ball1Obj;   //ページ数を示す四角の色変え
    public GameObject Ball2Obj;
    public GameObject Ball3Obj;

    public Material SetColor;     //下の四角の色の管理

    int PageNumber = 0;//0,1,2でページを管理する

    private void Start()
    {
        Page2UIObj.SetActive(false);
        Page2Obj.SetActive(false);
        Page0Show();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPage();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PrevPage();
        }
    }
    public void NextPage() 
    {
        if (PageNumber < 2)
        {
            PageNumber++;
            if (PageNumber==1)
            {
                Page1Show();
            }
            else if (PageNumber == 2) 
            {
                Page2Show();
            }
        }
        else
        {
            Debug.Log("この先はないよ！");
        }
    }

    public void PrevPage() 
    {
        if (PageNumber > 0)
        {
            PageNumber--;
            if (PageNumber == 0)
            {
                Page0Show();
            }
            else if (PageNumber == 1)
            {
                Page1Show();
            }
        }
        else
        {
            Debug.Log("この前はないよ！");
        }
    }

    public void Page0Show()
    {
        Page1UIObj.SetActive(false);
        Page1Obj.SetActive(false);

        Page0UIObj.SetActive(true);

        Ball2Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball3Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball1Obj.GetComponent<Renderer>().material.color = SetColor.color;
    }
    //次ページ、前ページの両方に参照できるため
    public void Page1Show()
    {
        Page0UIObj.SetActive(false);

        Page2UIObj.SetActive(false);
        Page2Obj.SetActive(false);

        Page1UIObj.SetActive(true);
        Page1Obj.SetActive(true);

        Ball1Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball3Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball2Obj.GetComponent<Renderer>().material.color = SetColor.color;
    }
    public void Page2Show()
    {
        Page1UIObj.SetActive(false);
        Page1Obj.SetActive(false);

        Page2UIObj.SetActive(true);
        Page2Obj.SetActive(true);

        Ball1Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball2Obj.GetComponent<Renderer>().material.color = Color.gray;
        Ball3Obj.GetComponent<Renderer>().material.color = SetColor.color;
    }
}
