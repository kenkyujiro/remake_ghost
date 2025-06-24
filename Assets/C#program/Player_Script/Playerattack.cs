using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public float attackRange = 5f; // Rayの距離
    public LayerMask enemyLayer; // 敵のレイヤーを指定

    void Update()
    {
        if(Time.timeScale != 0)//ポーズ状態でないとき、
        {
            //Vを押すと直接攻撃
            //何度も攻撃可能(クールタイムを作るべきか…)
            if (Input.GetKeyDown(KeyCode.V))
            {
                Attack();
                PushSound.Instance.S_DirectAttack();
            }
        }
    }

    void Attack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // プレイヤーの前方にRayを投げ、敵レイヤーに当たるかどうかをチェック
        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            // Rayが当たったオブジェクトがEnemyタグを持っているか確認
            if (hit.collider.CompareTag("eliminiate"))
            {
                // 敵の削除メソッドを呼び出す
                hit.collider.GetComponent<OnCollision_DestoryMe>().DestroySelf();
            }
        }
    }
}
