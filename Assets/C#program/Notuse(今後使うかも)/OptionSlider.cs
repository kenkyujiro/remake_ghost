using UnityEngine;
using UnityEngine.UI;

//汎用性のあるスライダー案
//まとめると却って管理が難しいと考えたため没
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
        // スライダー初期値を各設定から読み込む
        switch (settingType)
        {
            //各scriptにGetBGMVolumeを用意していないためエラーが発生している。実装例public float GetBGMVolume(){return bgmVolume;}
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

        // 値が変わったときのイベント登録
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

