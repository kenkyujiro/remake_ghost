using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    //自動プロパティ
    //Instanceはクラス外から取れる→public
    //しかし変更できないように→private set
    //クラス内でひとつだけ→static
    public static BGMManager Instance { get; private set; }

    AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//シングルトン化
        }
        else
        {
            Destroy(gameObject); // 既にあるなら自分は消える
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    //音量の調整用関数
    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void BGM_Play()//BGMの再生
    {
        audioSource.UnPause();//止まったところから再生
    }
    public void BGM_Stop()//BGMの一時停止
    {
        audioSource.Pause();//一時的に止める
    }
    public void BGM_Restart()//BGMのリスタート
    {
        audioSource.Stop();  // 再生を完全に止める（再生位置を0に戻す）
        audioSource.Play();  // 頭から再生する
    }

}
