using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//������ʂ���̑J�ڗp
public class SceneBack : MonoBehaviour
{
    public string BacksceneName;
    Pose_Timestop poseTimestop;

    private void Awake()
    {
        GameObject guy = GameObject.Find("Guy");
        if (guy == null)
        {
            Debug.Log("�Z�b�g�悪������܂���B:UI");
        }
        poseTimestop = guy.GetComponent<Pose_Timestop>();
    }

    public void BackScene()
    {
        poseTimestop.ApplicationPause();
        SoundManagerButton.Instance.S_ReStart();
        BGMManager.Instance.BGM_Stop();
        SceneManager.LoadScene(BacksceneName);
    }
}
