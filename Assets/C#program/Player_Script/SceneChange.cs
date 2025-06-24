using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//������ʂ���̑J�ڗp
public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        if (sceneName == "scene_explain")//�X�^�[�g��ʂ���̑J�ڎ�
        {
            SoundManagerButton.Instance.S_GameStart();
        }
        else
        {
            SoundManagerButton.Instance.S_ReStart();
        }

        //�����Q�[���V�[���ɑJ�ڂ���ꍇ��BGM���Đ�����
        if (sceneName == "scene_game")
        {
            BGMManager.Instance.BGM_Restart();
        }
        SceneManager.LoadScene(sceneName);
    }
}
