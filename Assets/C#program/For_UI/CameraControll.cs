using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject mainCamera;//メインカメラ格納用
    private GameObject testCamera;//テストカメラ格納用
    private GameObject subCamera;//テストカメラ格納用
    public string pushKey = "v";
    public string pushedKey = "p";

    bool pointFlag = true;

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラとテストカメラをそれぞれ取得
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        testCamera = GameObject.Find("TestCamera");

        //エラー回避のためサブカメラとテストカメラを非アクティブにする
        subCamera.SetActive(false);
        testCamera.SetActive(false);
    }


    void Update()
    {
        //vが押すと、もう片方のカメラをアクティブにする
        if (Input.GetKeyDown(pushKey))
        {

                if (pointFlag == true)
                {
                    //サブカメラをアクティブに設定
                    mainCamera.SetActive(false);
                    subCamera.SetActive(true);
                    testCamera.SetActive(false);
                    pointFlag = false;
                }
                else
                {
                    //メインカメラをアクティブに設定
                    testCamera.SetActive(false);
                    subCamera.SetActive(false);
                    mainCamera.SetActive(true);
                    pointFlag = true;
                }
            
        }
        if (Input.GetKeyDown(pushedKey))
        {

            if (pointFlag == true)
            {
                //サブカメラをアクティブに設定
                mainCamera.SetActive(false);
                subCamera.SetActive(false);
                testCamera.SetActive(true);
                pointFlag = false;
            }
            else
            {
                //メインカメラをアクティブに設定
                testCamera.SetActive(false);
                subCamera.SetActive(false);
                mainCamera.SetActive(true);
                pointFlag = true;
            }

        }
    }

}
