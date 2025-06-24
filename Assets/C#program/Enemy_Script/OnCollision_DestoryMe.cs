using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnCollision_DestoryMe : MonoBehaviour
{
    public string tagName;// タグ名：Inspectorで指定
    //public ScoreManager scoreManager;
    public GameObject newPrefab1;
    public GameObject newPrefab2;
    int rnd;

    //クラス上に定義しないと使えない
    private Sometime_RandomCreatePrefab createEnemy;

    public float offsetX = 0f;
    public float offsetY = 1f;
    public float offsetZ = 0f;

    void Start()
    {
        /*//最初に参照するスコアを定義
        GameObject scoreManagerObject = GameObject.Find("ScoreManager");
        if (scoreManagerObject != null)
        {
            scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
            if (scoreManager != null)
            {
                Debug.Log("ScoreManagerが見つかりました。");
            }
            else
            {
                Debug.LogError("ScoreManagerコンポーネントが見つかりませんでした。");
            }
        }
        else
        {
            Debug.LogError("ScoreManagerオブジェクトが見つかりませんでした。");
        }*/
        GameObject CreateEnemy = GameObject.Find("Spown Obake");
        if (CreateEnemy != null)
        {
            createEnemy = CreateEnemy.GetComponent<Sometime_RandomCreatePrefab>();

            if (createEnemy == null)
            {
                Debug.LogError("Sometime_RandomCreatePrefab が Spown Obake に見つかりません！");
            }
        }
        else
        {
            Debug.LogError("Spown Obake が見つかりません！");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //ぶつかった時に目的のタグネームを持っているかどうか
        if (collision.gameObject.tag == tagName)
        {
            //親子関係であるときで処理を変更する
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                createEnemy.Spown_number -= 1;
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
                CreateItemPrefab();
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
            createEnemy.Spown_number -= 1;
            Destroy(this.gameObject);
            CreateItemPrefab();
        }
    }

    void CreateItemPrefab()
    {
        //0から2の数を出力する
        rnd = Random.Range(0, 3);
        if (rnd == 0)//ハート生成
        {
            // プレハブからゲームオブジェクトを作る
            GameObject newGameObject = Instantiate(newPrefab1) as GameObject;
            //
            Vector3 newPos = this.transform.position;
            Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
            newPos = newPos + offset;
            newGameObject.transform.position = newPos;
        }
        else if (rnd == 1)//弾薬生成
        {
            // プレハブからゲームオブジェクトを作る
            GameObject newGameObject = Instantiate(newPrefab2) as GameObject;
            Vector3 newPos = this.transform.position;
            Vector3 offset = new Vector3(offsetX, offsetY, offsetZ);
            newPos = newPos + offset;
            newGameObject.transform.position = newPos;
        }
        else { }//はずれ処理
    }
}