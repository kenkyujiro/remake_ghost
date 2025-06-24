using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings Instance { get; private set; }

    // �ړ����x�Ɖ�]���x�����J�iInspector�Œ����\�j
    public float moveSpeed = 3f;
    public float rotateSpeed = 90f;

    public float maxHeart = 5f;

    private void Awake()
    {
        //���łɓ����I�u�W�F�N�g������΍폜�����
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
