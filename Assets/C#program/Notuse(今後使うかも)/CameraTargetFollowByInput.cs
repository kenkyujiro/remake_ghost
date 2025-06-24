using UnityEngine;

public class CameraTargetFollowByInput : MonoBehaviour
{
    public float speed = 3;        // プレイヤーのspeedに合わせる
    public float rotateSpeed = 90; // プレイヤーのrotateSpeedも同様

    public Transform player;       // プレイヤーのTransformの指定用

    float currentRotation = 0f;

    void Update()
    {
        // キーボード入力を取得
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 回転処理
        if (horizontal != 0)
        {
            float deltaAngle = horizontal * rotateSpeed * Time.deltaTime;
            currentRotation += deltaAngle;

            transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        }

        // 移動処理
        if (vertical != 0)
        {
            // プレイヤーの向きを考慮した移動方向を取得
            Vector3 moveDirection = transform.forward * vertical;
            // CameraTargetを移動（移動速度 × DeltaTime で滑らかに）
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
