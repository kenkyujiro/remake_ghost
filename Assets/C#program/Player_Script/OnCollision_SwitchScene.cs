using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// 衝突したら、シーンを切り換える
public class OnCollision_SwitchScene : MonoBehaviour
{
	public string tagName; // 目標タグ名：Inspectorで指定
    public string tagName1;
    public string sceneName = "";  // シーン名：Inspectorで指定
	public float Heart = 5;// ライフの最大値
	public float hurt = 1; // ダメージの量
    [SerializeField] private HealthBarHUDTester healthTester;

    private void Start()
    {
        // シーン開始時に最大ライフから現在ライフを初期化
        Heart = GameSettings.Instance.maxHeart;
    }

    private void OnCollisionEnter(Collision collision) // 衝突したとき
	{
        // もし、衝突したものが目標のタグを持っていたら
        if (collision.gameObject.tag == tagName || collision.gameObject.tag == tagName1)
		{
            Heart -= hurt;
            
            if (Heart > 0)
			{
                healthTester.Hurt(hurt);
                Debug.Log("残ってる");
				Debug.Log("残りHP：" + Heart);
                PushSound.Instance.S_Damage();
                //ぶつかったのが敵の弾かどうかで処理が変わる
                if(collision.gameObject.tag == tagName)
                {
                    //弾以外である場合は、敵の沸き上限に関わるため、下記関数を呼び出す
                    collision.collider.GetComponent<OnCollision_DestoryMe>().DestroySelf();
                }
                else
                {
                    //ぶつかったのが弾である場合
                    Destroy(collision.gameObject);
                }
                
            }
			else if(Heart <= 0)
			{
                Debug.Log("死にました");
                Destroy(collision.gameObject);
                if (sceneName != "")// シーン名があれば、切り換える
				{
					SceneManager.LoadScene (sceneName);
                    BGMManager.Instance.BGM_Stop();
                } 
				else
				{
					Debug.Log("次のシーンがありません！");
				}
            }
        }
	}

    public void DestroySelf()
    {
		Destroy(this.gameObject);
    }

}
