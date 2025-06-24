using UnityEngine;
using UnityEngine.UI;

//�ėp���̂���X���C�_�[��
//�܂Ƃ߂�Ƌp���ĊǗ�������ƍl�������ߖv
public class OptionSlider : MonoBehaviour
{
    public enum SettingType
    {
        BGMVolume,
        SEVolume,
        RotateSpeed
    }

    [SerializeField] private SettingType settingType;
    [SerializeField] private Slider slider;

    private void Start()
    {
        // �X���C�_�[�����l���e�ݒ肩��ǂݍ���
        switch (settingType)
        {
            //�escript��GetBGMVolume��p�ӂ��Ă��Ȃ����߃G���[���������Ă���B������public float GetBGMVolume(){return bgmVolume;}
            case SettingType.BGMVolume:
                //slider.value = BGMManager.Instance != null ? BGMManager.Instance.GetBGMVolume() : 0.5f;
                //break;
            case SettingType.SEVolume:
                //slider.value = PushSound.Instance != null ? PushSound.Instance.GetSEVolume() : 0.5f;
                //break;
            case SettingType.RotateSpeed:
                slider.value = GameSettings.Instance != null ? GameSettings.Instance.rotateSpeed : 90f;
                break;
        }

        // �l���ς�����Ƃ��̃C�x���g�o�^
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        switch (settingType)
        {
            case SettingType.BGMVolume:
                if (BGMManager.Instance != null)
                    BGMManager.Instance.SetBGMVolume(value);
                break;
            case SettingType.SEVolume:
                if (PushSound.Instance != null)
                    PushSound.Instance.SetSEVolume(value);
                break;
            case SettingType.RotateSpeed:
                if (GameSettings.Instance != null)
                    GameSettings.Instance.rotateSpeed = value;
                break;
        }
    }
}

