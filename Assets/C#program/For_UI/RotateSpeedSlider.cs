using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RotateSpeedSlider : MonoBehaviour
{
    [SerializeField] private Slider rotateSlider;
    [SerializeField] private TextMeshProUGUI valueText;  //スライダーの数値表示

    private void Start()
    {
        //GameSettings から現在値を読み込み
        rotateSlider.value = GameSettings.Instance.rotateSpeed;
        UpdateValueText(rotateSlider.value);

        //スライダーのChangedにイベントを追加
        rotateSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void OnSliderValueChanged(float value)
    {
        // (一応)小数点以下切り捨て、Whole Numbersがあるため不要なはず
        int intValue = Mathf.RoundToInt(value);

        // GameSettings(Object)に反映
        GameSettings.Instance.rotateSpeed = intValue;

        UpdateValueText(intValue);
    }

    private void UpdateValueText(float value)
    {
        if (valueText != null)
        {
            //テキストとして整数表示
            valueText.text = value.ToString("F0");
        }
    }
}
