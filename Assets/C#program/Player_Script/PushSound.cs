using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSound : MonoBehaviour
{
    //������script�Ŏg�����߁A�C���X�^���X��
    public static PushSound Instance { get; private set; }

    //BGM�̊Ǘ���
    public BGMManager bgmManager;

    //SE�̈ꗗ
    public AudioClip sound_shot;
    public AudioClip sound_rerode;
    public AudioClip sound_outAmmo;
    public AudioClip sound_directattack;
    public AudioClip sound_heal;
    public AudioClip sound_pose;
    public AudioClip sound_poseCancel;
    public AudioClip sound_damage;

    private AudioSource audioSource;
    //���ʂ̊Ǘ�
    public float seVolume = 1.0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//�V���O���g����
        }
        else
        {
            Destroy(gameObject); // ����������������d�����폜(�G���[���p)
            return;
        }

        audioSource = GetComponent<AudioSource>();

        //�|�[�Y����BGM�̐���p�Ɏ擾
        if (bgmManager == null) // Inspector �Őݒ肳��Ă��Ȃ������ꍇ
        {
            GameObject bgmObj = GameObject.Find("SoundManager(BGM)");
            if (bgmObj != null)
            {
                bgmManager = bgmObj.GetComponent<BGMManager>();
            }

            if (bgmManager == null)
            {
                Debug.LogError("BGMManager ��������܂���IPushSound �� null �ɂȂ�܂��I");
            }
        }
    }

    //���ʒ����p�̊֐�
    public void SetSEVolume(float volume)
    {
        seVolume = volume;
        //audioSource.volume = seVolume;
    }

    public void S_Shot()//�e�e���ˎ�(space)
    {
        audioSource.PlayOneShot(sound_shot, seVolume);
    }
    public void S_DirectAttack()//�U����(V)
    {
        audioSource.PlayOneShot(sound_directattack, seVolume);
    }

    public void S_Heal()//�n�[�g�擾��
    {
        audioSource.PlayOneShot(sound_heal, seVolume);
    }

    public void S_Rerode()//�e�e�擾��
    {
        audioSource.PlayOneShot(sound_rerode, seVolume);
    }

    public void S_OutAmmo()//�e�؂ꎞ
    {
        audioSource.PlayOneShot(sound_outAmmo, seVolume);
    }

    
    public void S_Pose()//�|�[�Y��(�|�[�Y�����t�������������A�G���[�ɂȂ��Ă��܂����c)
    {
        //audioSource.PlayOneShot(sound_pose);
        bgmManager.BGM_Stop();
    }

    public void S_PoseCancel()//�|�[�Y������
    {
        bgmManager.BGM_Play();
        //audioSource.PlayOneShot(sound_poseCancel);
    }

    public void S_Damage()
    {
        audioSource.PlayOneShot(sound_damage, seVolume);
    }
}
