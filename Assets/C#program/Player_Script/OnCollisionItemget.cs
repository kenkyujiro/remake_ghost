using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// 衝突したら、シーンを切り換える
public class OnCollisionItemget : MonoBehaviour
{
    public string tagName_Heal;
    public string tagName_Bullet;
    public float heal = 1;
    [SerializeField] private HealthBarHUDTester healthTester;//表示上のハート管理
    [SerializeField] private OnCollision_SwitchScene OnCollision_Guy;//数値上のハート管理
    [SerializeField] private OnKeyPress_Throw OnKeyPress_Throw;//プレイヤー弾薬を行っている

    private void OnCollisionEnter(Collision collision)
    {
        //ヒールアイテム取得時
        if (collision.gameObject.tag == tagName_Heal)
        {
            if(OnCollision_Guy.Heart >= 5) 
            {
                Debug.Log("上限だよ！");
                Debug.Log("残りHP：" + OnCollision_Guy.Heart);
                PushSound.Instance.S_Heal();
                Destroy(collision.gameObject);
            }
            else
            {
                OnCollision_Guy.Heart += 1;
                if(OnCollision_Guy.Heart > 5)
                {
                    OnCollision_Guy.Heart = 5;
                }
                healthTester.Heal(heal);
                Debug.Log("回復だよ！");
                Debug.Log("残りHP：" + OnCollision_Guy.Heart);
                PushSound.Instance.S_Heal();
                Destroy(collision.gameObject);
            }
            
        }
        //弾薬アイテム取得時
        else if(collision.gameObject.tag == tagName_Bullet)
        {
            if(OnKeyPress_Throw.rerode >= 10)
            {
                Debug.Log("弾薬はいっぱい！");
                Debug.Log("残り弾数：" + OnKeyPress_Throw.rerode);
                PushSound.Instance.S_Rerode();
                Destroy(collision.gameObject);
            }
            else 
            {
                OnKeyPress_Throw.bullet();
                Debug.Log("リロード!");
                Debug.Log("残り弾数：" + OnKeyPress_Throw.rerode);
                PushSound.Instance.S_Rerode();
                Destroy(collision.gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

}