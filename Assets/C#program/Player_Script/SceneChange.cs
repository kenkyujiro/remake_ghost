using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//説明画面からの遷移用
public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    public void ChangeScene()
    {
        if (sceneName == "scene_explain")//スタート画面からの遷移時
        {
            SoundManagerButton.Instance.S_GameStart();
        }
        else
        {
            SoundManagerButton.Instance.S_ReStart();
        }

        //もしゲームシーンに遷移する場合はBGMを再生する
        if (sceneName == "scene_game")
        {
            BGMManager.Instance.BGM_Restart();
        }
        SceneManager.LoadScene(sceneName);
    }
}
