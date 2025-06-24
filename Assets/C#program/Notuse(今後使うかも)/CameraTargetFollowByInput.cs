using UnityEngine;

public class CameraTargetFollowByInput : MonoBehaviour
{
    public float speed = 3;        // �v���C���[��speed�ɍ��킹��
    public float rotateSpeed = 90; // �v���C���[��rotateSpeed�����l

    public Transform player;       // �v���C���[��Transform�̎w��p

    float currentRotation = 0f;

    void Update()
    {
        // �L�[�{�[�h���͂��擾
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ��]����
        if (horizontal != 0)
        {
            float deltaAngle = horizontal * rotateSpeed * Time.deltaTime;
            currentRotation += deltaAngle;

            transform.rotation = Quaternion.Euler(0, currentRotation, 0);
        }

        // �ړ�����
        if (vertical != 0)
        {
            // �v���C���[�̌������l�������ړ��������擾
            Vector3 moveDirection = transform.forward * vertical;
            // CameraTarget���ړ��i�ړ����x �~ DeltaTime �Ŋ��炩�Ɂj
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
