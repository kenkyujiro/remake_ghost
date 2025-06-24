using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateSpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider rotateSlider;
    [SerializeField] private TextMeshProUGUI valueText;  //�X���C�_�[�̐��l�\��

    private void Start()
    {
        //GameSettings ���猻�ݒl��ǂݍ���
        rotateSlider.value = GameSettings.Instance.rotateSpeed;
        UpdateValueText(rotateSlider.value);

        //�X���C�_�[��Changed�ɃC�x���g��ǉ�
        rotateSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        // (�ꉞ)�����_�ȉ��؂�̂āAWhole Numbers�����邽�ߕs�v�Ȃ͂�
        int intValue = Mathf.RoundToInt(value);

        // GameSettings(Object)�ɔ��f
        GameSettings.Instance.rotateSpeed = intValue;

        UpdateValueText(intValue);
    }

    private void UpdateValueText(float value)
    {
        if (valueText != null)
        {
            //�e�L�X�g�Ƃ��Đ����\��
            valueText.text = value.ToString("F0");
        }
    }
}
