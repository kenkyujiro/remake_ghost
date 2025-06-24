using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerButton : MonoBehaviour
{
    public static SoundManagerButton Instance { get; private set; }

    public AudioClip sound_restart;
    public AudioClip sound_gamestart;

    private AudioSource audioSource;

    public bool DontDestroyEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); //�V���O���g����
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void S_ReStart()//���X�^�[�g�{�^���Đ���
    {
        audioSource.PlayOneShot(sound_restart);
    }

    public void S_GameStart()//(�X�^�[�g��ʂ�)�Q�[���X�^�[�g��
    {
        audioSource.PlayOneShot(sound_gamestart);
    }
}
