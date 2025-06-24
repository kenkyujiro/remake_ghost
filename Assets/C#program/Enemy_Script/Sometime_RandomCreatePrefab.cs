using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ときどき、範囲内にランダムにプレハブからゲームオブジェクトを作る
public class Sometime_RandomCreatePrefab : MonoBehaviour
{
	public GameObject newPrefab1; // プレハブ：Inspectorで指定
    public GameObject newPrefab2;
    public float intervalSec = 1; // 作成間隔（秒）：Inspectorで指定する
	int rnd;
    public int limit_number, Spown_number; //沸き上限と現在の沸き数


    void Start() // 最初に
	{
		// コライダーを削除
		Collider col = this.gameObject.GetComponent<Collider>();
		if (col)
		{
			Destroy(col);
		}
        //リセット(最初に3匹がシーン内にいるため)
        Spown_number = 3;
		// 指定秒ごとに、くり返し実行する予約をする
		InvokeRepeating("CreatePrefab", intervalSec, intervalSec);
	}

	void CreatePrefab()
	{
        //設定した沸き上限以内であれば沸かせる
        if (Spown_number <= limit_number)
        {
            //0か1の数を出力する
            rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                // このオブジェクトの範囲内にランダムに
                Vector3 area = GetComponent<Renderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                //Navmeshのエリアを参照している？
                newPos.x += Random.Range(-area.x / 2, area.x / 2);
                newPos.y += Random.Range(-area.y / 2, area.y / 2);
                newPos.z += Random.Range(-area.z / 2, area.z / 2);
                // プレハブからゲームオブジェクトを作る
                GameObject newGameObject = Instantiate(newPrefab1) as GameObject;
                newGameObject.transform.position = newPos;
                Spown_number++;
            }
            else
            {
                // このオブジェクトの範囲内にランダムに
                Vector3 area = GetComponent<Renderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                //Navmeshのエリアを参照している？
                newPos.x += Random.Range(-area.x / 2, area.x / 2);
                newPos.y += Random.Range(-area.y / 2, area.y / 2);
                newPos.z += Random.Range(-area.z / 2, area.z / 2);
                // プレハブからゲームオブジェクトを作る
                GameObject newGameObject = Instantiate(newPrefab2) as GameObject;
                newGameObject.transform.position = newPos;
                Spown_number++;
            }
        }
		
	}
}
