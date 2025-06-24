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
        //�ύX����ӏ����`����
        GameObject bulletTextObject = GameObject.Find("BulletText");
        if (bulletTextObject != null)
        {
            //10�Ƃ��������񎩑̂��w�肵�Ă���
            bulletText = bulletTextObject.GetComponent<TextMeshProUGUI>();
            if (bulletText != null)
            {
                bulletText.text = "0";
            }
            else
            {
                Debug.LogError("TextMeshProUGUI�R���|�[�l���g��������܂���ł����B");
            }
        }
        else
        {
            Debug.LogError("BulletText�I�u�W�F�N�g��������܂���ł����B");
        }
    }

    //����X�V����
    void Update()
    {
        if (bulletText != null)
        {
            bulletText.text = bullet.ToString();
        }
    }

    //�\�����-1����
    public void decreaseBullet()
    {
        bullet -= 1;
    }

    //�\����Ń����[�h(�e���10��)����
    public void rerodeBullet()
    {
        bullet = 10;
    }
}
