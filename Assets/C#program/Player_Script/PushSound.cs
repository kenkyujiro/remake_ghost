using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSound : MonoBehaviour
{
    //複数のscriptで使うため、インスタンス化
    public static PushSound Instance { get; private set; }

    //BGMの管理先
    public BGMManager bgmManager;

    //SEの一覧
    public AudioClip sound_shot;
    public AudioClip sound_rerode;
    public AudioClip sound_outAmmo;
    public AudioClip sound_directattack;
    public AudioClip sound_heal;
    public AudioClip sound_pose;
    public AudioClip sound_poseCancel;
    public AudioClip sound_damage;

    private AudioSource audioSource;
    //音量の管理
    public float seVolume = 1.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//シングルトン化
        }
        else
        {
            Destroy(gameObject); // もし複数あったら重複を削除(エラー回避用)
            return;
        }

        audioSource = GetComponent<AudioSource>();

        //ポーズ時にBGMの制御用に取得
        if (bgmManager == null) // Inspector で設定されていなかった場合
        {
            GameObject bgmObj = GameObject.Find("SoundManager(BGM)");
            if (bgmObj != null)
            {
                bgmManager = bgmObj.GetComponent<BGMManager>();
            }

            if (bgmManager == null)
            {
                Debug.LogError("BGMManager が見つかりません！PushSound で null になります！");
            }
        }
    }

    //音量調整用の関数
    public void SetSEVolume(float volume)
    {
        seVolume = volume;
        //audioSource.volume = seVolume;
    }

    public void S_Shot()//銃弾発射時(space)
    {
        audioSource.PlayOneShot(sound_shot, seVolume);
    }
    public void S_DirectAttack()//攻撃時(V)
    {
        audioSource.PlayOneShot(sound_directattack, seVolume);
    }

    public void S_Heal()//ハート取得時
    {
        audioSource.PlayOneShot(sound_heal, seVolume);
    }

    public void S_Rerode()//銃弾取得時
    {
        audioSource.PlayOneShot(sound_rerode, seVolume);
    }

    public void S_OutAmmo()//弾切れ時
    {
        audioSource.PlayOneShot(sound_outAmmo, seVolume);
    }

    
    public void S_Pose()//ポーズ時(ポーズ音も付けたかったが、エラーになってしまった…)
    {
        //audioSource.PlayOneShot(sound_pose);
        bgmManager.BGM_Stop();
    }

    public void S_PoseCancel()//ポーズ解除時
    {
        bgmManager.BGM_Play();
        //audioSource.PlayOneShot(sound_poseCancel);
    }

    public void S_Damage()
    {
        audioSource.PlayOneShot(sound_damage, seVolume);
    }
}
