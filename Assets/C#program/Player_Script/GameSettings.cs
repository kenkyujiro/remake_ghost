using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    // 移動速度と回転速度を公開（Inspectorで調整可能）
    public float moveSpeed = 3f;
    public float rotateSpeed = 90f;

    public float maxHeart = 5f;

    private void Awake()
    {
        //すでに同じオブジェクトがあれば削除される
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
