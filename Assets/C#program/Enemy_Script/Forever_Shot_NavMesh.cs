using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forever_Shot_Navmesh : MonoBehaviour
{
    //シリアライズ…プレハブを使うために行うバイト列変換
    //インスペクタ―からaccess(入力)したいときに使う
    //しかし、privateが使えるため他のクラスからの書き換えを防ぐ
    [SerializeField] GameObject player;
    [SerializeField] GameObject ball;
    private float ballSpeed = 1.0f;
    private float time = 2.0f;

    void Start()
    {
        //インスペクターで設定されていない場合のみ取得
        if (player == null) 
        {
            player = GameObject.FindWithTag("player");
            if (player == null)
            {
                Debug.LogError("Forever_Shot_Navmesh: シーン内に 'Player' タグのついたオブジェクトが見つかりません！");
            }
        }
    }


    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("player");
            // まだプレイヤーが見つからない場合は処理をスキップ
            if (player == null) return;
        }

        // 向きをplayer方向にする
        transform.LookAt(player.transform);

        // 時間をフレーム単位で管理する
        time -= Time.deltaTime;
        if (time <= 0)
        {
            BallShot();
            time = 4f;
        }
    }

    void BallShot()
    {
        //object生成関数(object名,生成位置,生成向き)
        Vector3 spawnPosition = transform.position + transform.forward * 1.0f; // 敵の前方1mに弾を生成
        //Vector3 spawnPosition = targetObject.transform.position + transform.forward * 1.0f;
        GameObject shotObj = Instantiate(ball, spawnPosition, Quaternion.identity);
        shotObj.GetComponent<Rigidbody>().velocity = transform.forward * ballSpeed;
    }
}