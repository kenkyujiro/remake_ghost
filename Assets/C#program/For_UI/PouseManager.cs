using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image���g����悤�ɂ��邽��

public class PouseManager : MonoBehaviour
{
    public GameObject Page1UIObj;   //�y�[�W���Ƃ̗v�f�̊Ǘ�
    public GameObject Page2UIObj;
    public GameObject Square1Obj;   //�y�[�W���������l�p�̊Ǘ�
    public GameObject Square2Obj;
    private Image square1Image;     //�C���[�W�R���|�[�l���g�擾�p
    private Image square2Image;

    public Material SetColor;     //���̎l�p�̐F�̊Ǘ�

    public int PageNumber = 1;//1,2�Ńy�[�W���Ǘ�����

    void Start()
    {
        // Square(Page_1/2(Panel))�ɃA�^�b�`����Ă���Image�R���|�[�l���g���擾
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
