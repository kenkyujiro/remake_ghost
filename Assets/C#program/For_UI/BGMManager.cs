using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    //�����v���p�e�B
    //Instance�̓N���X�O������遨public
    //�������ύX�ł��Ȃ��悤�Ɂ�private set
    //�N���X���łЂƂ�����static
    public static BGMManager Instance { get; private set; }

    AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);//�V���O���g����
        }
        else
        {
            Destroy(gameObject); // ���ɂ���Ȃ玩���͏�����
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    //���ʂ̒����p�֐�
    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void BGM_Play()//BGM�̍Đ�
    {
        audioSource.UnPause();//�~�܂����Ƃ��납��Đ�
    }
    public void BGM_Stop()//BGM�̈ꎞ��~
    {
        audioSource.Pause();//�ꎞ�I�Ɏ~�߂�
    }
    public void BGM_Restart()//BGM�̃��X�^�[�g
    {
        audioSource.Stop();  // �Đ������S�Ɏ~�߂�i�Đ��ʒu��0�ɖ߂��j
        audioSource.Play();  // ������Đ�����
    }

}
