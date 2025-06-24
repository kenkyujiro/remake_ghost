using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BulletManager : MonoBehaviour
{
    private TextMeshProUGUI bulletText;
    public int bullet = 10;
    // Start is called before the first frame update
    void Start()
    {
        //変更する箇所を定義する
        GameObject bulletTextObject = GameObject.Find("BulletText");
        if (bulletTextObject != null)
        {
            //10という文字列自体を指定している
            bulletText = bulletTextObject.GetComponent<TextMeshProUGUI>();
            if (bulletText != null)
            {
                bulletText.text = "0";
            }
            else
            {
                Debug.LogError("TextMeshProUGUIコンポーネントが見つかりませんでした。");
            }
        }
        else
        {
            Debug.LogError("BulletTextオブジェクトが見つかりませんでした。");
        }
    }

    //逐一更新する
    void Update()
    {
        if (bulletText != null)
        {
            bulletText.text = bullet.ToString();
        }
    }

    //表示上で-1する
    public void decreaseBullet()
    {
        bullet -= 1;
    }

    //表示上でリロード(弾薬を10に)する
    public void rerodeBullet()
    {
        bullet = 10;
    }
}
