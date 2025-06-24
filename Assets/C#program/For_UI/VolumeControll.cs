using Unity.VisualScripting;
using UnityEngine;

public class VolumeControll : MonoBehaviour
{

    public void SetBGMVolume(float volume)
    {
        Debug.Log("BGM volume set to: " + volume);
        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.SetBGMVolume(volume);
        }
    }

    public void SetSEVolume(float volume)
    {
        Debug.Log("SE volume set to: " + volume);
        if (PushSound.Instance != null)
        {
            PushSound.Instance.SetSEVolume(volume);
        }
    }
}
