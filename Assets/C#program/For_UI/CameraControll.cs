using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    private GameObject mainCamera;//���C���J�����i�[�p
    private GameObject testCamera;//�e�X�g�J�����i�[�p
    private GameObject subCamera;//�e�X�g�J�����i�[�p
    public string pushKey = "v";
    public string pushedKey = "p";

    bool pointFlag = true;

    //�Ăяo�����Ɏ��s�����֐�
    void Start()
    {
        //���C���J�����ƃT�u�J�����ƃe�X�g�J���������ꂼ��擾
        mainCamera = GameObject.Find("Main Camera");
        subCamera = GameObject.Find("Sub Camera");
        testCamera = GameObject.Find("TestCamera");

        //�G���[����̂��߃T�u�J�����ƃe�X�g�J�������A�N�e�B�u�ɂ���
        subCamera.SetActive(false);
        testCamera.SetActive(false);
    }


    void Update()
    {
        //v�������ƁA�����Е��̃J�������A�N�e�B�u�ɂ���
        if (Input.GetKeyDown(pushKey))
        {

                if (pointFlag == true)
                {
                    //�T�u�J�������A�N�e�B�u�ɐݒ�
                    mainCamera.SetActive(false);
                    subCamera.SetActive(true);
                    testCamera.SetActive(false);
                    pointFlag = false;
                }
                else
                {
                    //���C���J�������A�N�e�B�u�ɐݒ�
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
                //�T�u�J�������A�N�e�B�u�ɐݒ�
                mainCamera.SetActive(false);
                subCamera.SetActive(false);
                testCamera.SetActive(true);
                pointFlag = false;
            }
            else
            {
                //���C���J�������A�N�e�B�u�ɐݒ�
                testCamera.SetActive(false);
                subCamera.SetActive(false);
                mainCamera.SetActive(true);
                pointFlag = true;
            }

        }
    }

}
