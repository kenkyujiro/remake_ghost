using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//MonoBehaviour, IPointerEnterHandler, IPointerExitHandler→クラスの継承を行う
public class ButtonColor_Arrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void Start()
    {
        this.GetComponent<Image>().color = Color.white;
    }
    //マウスカーソルが重なったとき
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color32(181, 181, 181, 255);
    }

    //マウスカーソルが離れたとき
    public void OnPointerExit(PointerEventData eventData)
    {
        //RGBとアルファ値を0〜255の整数(byte)で扱う
        this.GetComponent<Image>().color = Color.white;
    }
}