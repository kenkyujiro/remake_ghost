using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//MonoBehaviour, IPointerEnterHandler, IPointerExitHandler���N���X�̌p�����s��
public class ButtonColorSet : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void Start()
    {
        this.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }
    //�}�E�X�J�[�\�����d�Ȃ����Ƃ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = Color.green;
    }

    //�}�E�X�J�[�\�������ꂽ�Ƃ�
    public void OnPointerExit(PointerEventData eventData)
    {
        //RGB�ƃA���t�@�l��0�`255�̐���(byte)�ň���
        this.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
    }
}
