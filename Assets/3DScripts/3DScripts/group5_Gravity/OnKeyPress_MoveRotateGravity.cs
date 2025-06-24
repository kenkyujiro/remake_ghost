using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーを押したら、移動＆回転＆ジャンプする
public class OnKeyPress_MoveRotateGravity : MonoBehaviour
{
    //public float speed = 3;        // スピード：Inspectorで指定
    //public float rotateSpeed = 90; // 回転スピード：Inspectorで指定

    float vz = 0;   //移動スピード
    float angle = 0;//回転速度
    Rigidbody rbody;

    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
        rbody.constraints = RigidbodyConstraints.FreezeRotationX |
                     RigidbodyConstraints.FreezeRotationZ |
                     RigidbodyConstraints.FreezePositionY;

        // ここでGameSettings.Instanceが確実に存在している想定
        if (GameSettings.Instance == null)
        {
            Debug.LogError("GameSettingsが存在しません！");
        }

    }

    void Update()
    {
        //矢印の他に、WASDも反応する
        angle = Input.GetAxisRaw("Horizontal") * GameSettings.Instance.rotateSpeed;
        vz = Input.GetAxisRaw("Vertical") * GameSettings.Instance.moveSpeed;

    }

    private void FixedUpdate()
    {
        // 移動する
        if (vz != 0)
        {
            Vector3 move = transform.forward * vz * Time.fixedDeltaTime;
            rbody.MovePosition(rbody.position + move);
        }

        // 回転する
        if (angle != 0)
        {
            Quaternion rotation = Quaternion.Euler(0, angle * Time.fixedDeltaTime, 0);
            rbody.MoveRotation(rbody.rotation * rotation);
        }
    }

}
