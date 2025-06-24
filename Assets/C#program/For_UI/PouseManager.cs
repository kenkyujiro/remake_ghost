using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Imageを使えるようにするため

public class PouseManager : MonoBehaviour
{
    public GameObject Page1UIObj;   //ページごとの要素の管理
    public GameObject Page2UIObj;
    public GameObject Square1Obj;   //ページ数を示す四角の管理
    public GameObject Square2Obj;
    private Image square1Image;     //イメージコンポーネント取得用
    private Image square2Image;

    public Material SetColor;     //下の四角の色の管理

    public int PageNumber = 1;//1,2でページを管理する

    void Start()
    {
        // Square(Page_1/2(Panel))にアタッチされているImageコンポーネントを取得
        square1Image = Square1Obj.GetComponent<Image>();
        square2Image = Square2Obj.GetComponent<Image>();
    }

    void Update()
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
        if (PageNumber == 1)
        {
            PageNumber++;
            Page2Show();
        }
    }

    public void PrevPage()
    {
        if (PageNumber == 2)
        {
            PageNumber--;
            Page1Show();
        }
    }

    public void Page1Show()
    {
        Page2UIObj.SetActive(false);

        Page1UIObj.SetActive(true);

        square1Image.color = SetColor.color;
        square2Image.color = Color.gray;
    }
    public void Page2Show()
    {
        Page1UIObj.SetActive(false);

        Page2UIObj.SetActive(true);

        square1Image.color = Color.gray;
        square2Image.color = SetColor.color;
    }
}
