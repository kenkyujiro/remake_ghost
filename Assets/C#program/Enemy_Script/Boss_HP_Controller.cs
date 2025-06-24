using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_HP_Controller : MonoBehaviour
{
    int maxHp = 25;
    int currentHp;
    //スライダーの取得
    public Slider slider;

    void Start()
    {
        slider.value = 1;  //満タンにする
        currentHp = maxHp; //マックスを反映
        Debug.Log("Start currentHp : " + currentHp);
    }

    public void OnDamage()
    {
        currentHp = currentHp - 1;
        //最大HPにおける現在のHPをSliderに反映。
        //int同士の割り算は小数点以下は0になるので、
        //floatの変数として振舞わせる。
        slider.value = (float)currentHp / (float)maxHp; ;
        Debug.Log("slider.value : " + slider.value);
    }
}
