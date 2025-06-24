using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollision_DestoryMe_BOSS : MonoBehaviour
{
    public string tagName;
    public string sceneName = "";
    public GameObject BossHPController;

    public int Boss_Life = 3;

    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった時に目的のタグネームを持っているかどうか
        if (collision.gameObject.tag == tagName)
        {
            Debug.Log("目標のタグと衝突しました。タグ名: " + collision.gameObject.tag); // タグが正しいか確認
            //親子関係であるときで処理を変更する
            if (Boss_Life <= 1 && transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            //ボスの体力が1以下である場合は撃破、ゲームクリアシーンに遷移
            else if(Boss_Life <= 1)
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                if (sceneName != "")  // シーン名があれば、切り換える
                {
                    SceneManager.LoadScene(sceneName);
                    BGMManager.Instance.BGM_Stop();
                }
                else
                {   // シーン名がなければ、次のシーンへ切り換える
                    int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
                    if (nextIndex < SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene(nextIndex);
                    }
                    else
                    {   // 次のシーンがなければ、最初のシーンに切り換える
                        SceneManager.LoadScene(0);
                    }
                }
            }
            else 
            {
                Boss_Life -= 1;
                BossHPController.GetComponent<Boss_HP_Controller>().OnDamage();
                Destroy(collision.gameObject);
            }
        }
        else
        {
        }
    }

    public void DestroySelf()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}