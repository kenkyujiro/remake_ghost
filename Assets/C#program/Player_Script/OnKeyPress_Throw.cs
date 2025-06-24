using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// キーを押したら、ゲームオブジェクトを作って投げる
public class OnKeyPress_Throw : MonoBehaviour
{
	public GameObject newPrefab; // プレハブ：Inspectorで指定
	public string pushKey = "z"; // 押すキー：Inspectorで指定
	public float throwPower = 4;
	public float offsetX = 0f;   // 作る位置の高さオフセット：Inspectorで指定
	public float offsetY = 1f;   // 作る位置の高さオフセット：Inspectorで指定
	public float offsetZ = 0.5f; // 作る位置の高さオフセット：Inspectorで指定

	bool pushFlag = false;
	public int rerode = 10;//弾数管理
    public BulletManager bulletManager;

    void Start()//BulletManagerを見つけておく(文字列)
    {
		//BulletManagerというobjectを取得する
        GameObject bulletManagerObject = GameObject.Find("BulletManager");
        if (bulletManagerObject != null)
        {
            bulletManager = bulletManagerObject.GetComponent<BulletManager>();
            if (bulletManager != null){}
            else
            {
                Debug.LogError("BulletManagerコンポーネントが見つかりませんでした。");
            }
        }
        else
        {
            Debug.LogError("BulletManagerオブジェクトが見つかりませんでした。");
        }
    }

    void Update() // ずっと、行う
	{
		if(Time.timeScale != 0)//ポーズ状態でないとき、
		{
			if (Input.GetKey(pushKey))//もし、キーが押されて
			{
				if (pushFlag == false && rerode > 0)//弾数が0かつ押しっぱなしでなければ
				{
					pushFlag = true; // 押した状態に
									 //プログラム上で-1する
					rerode -= 1;
					//テキスト上で-1する
					bulletManager.decreaseBullet();

					Vector3 newPos = this.transform.position;
					//方向決定
					Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
					offset = this.transform.rotation * offset;
					newPos = newPos + offset;

					// プレハブからゲームオブジェクトを作って
					GameObject newGameObject = Instantiate(newPrefab) as GameObject;
					newGameObject.transform.position = newPos;
					// 投げる
					Rigidbody rbody = newGameObject.GetComponent<Rigidbody>();
					rbody.useGravity = false;//重力無視
					Vector3 throwV = this.transform.forward * throwPower;
					rbody.velocity = throwV;//速度を直接設定
                    PushSound.Instance.S_Shot();
                }
				else if(pushFlag == false && rerode == 0)//弾切れのとき
				{
					pushFlag = true;
                    PushSound.Instance.S_OutAmmo();
                }
			} else
			{
				pushFlag = false;// 押した状態解除
			}
		}
	}

	public void bullet() 
	{
		rerode = 10;
        bulletManager.rerodeBullet();
    }
}
