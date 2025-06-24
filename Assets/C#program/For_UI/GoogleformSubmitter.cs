using System.Collections;//�R���[�`��(�ꎞ���f�@�\�����\��)���g������
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;//web�ʐM�@�\������
using TMPro;//TextMeshPro��InputField���g������

public class GoogleformSubmitter : MonoBehaviour
{
    //���M������e�ƕR�Â���e�L�X�g�B
    public TMP_InputField titleInput;   //�₢���킹���e
    public TMP_InputField messageInput; //�₢���킹�ڍ�

    // Google�t�H�[���̑��M��URL(���ڃ|�X�g�p��URL)(/view����ϊ�����K�v������)
    private string formUrl = "https://docs.google.com/forms/d/e/1FAIpQLSeVaEg426qtw94aHgLccIm-rjg0Vg9q9-5TD-_MS7iO8Rs6lg/formResponse";

    // �e�t�B�[���h�� entry.ID�iGoogle�t�H�[���̊J���҃c�[�����璲�ׂ����́j
    private string titleEntryID = "entry.1826561722";
    private string messageEntryID = "entry.1038773362";

    public OptionMenu formMenu;
    public GameObject SuccessPanel;

    private void Start()
    {
        SuccessPanel.SetActive(false);
    }
    //Onclick�ɓ\��t����p
    public void OnSubmit()
    {
        StartCoroutine(PostToGoogleForm());
    }

    //�����̂��L�����Z���������ꍇ
    public void Cancel()
    {
        //�L�q�������e����ɂ���
        titleInput.text = "";
        messageInput.text = "";

        //form���j���[�����
        if (formMenu != null)
        {
            formMenu.Option_Close();
        }
        else
        {
            Debug.Log("formMenu������`�ł��I");
        }
    }

    //���M����
    IEnumerator PostToGoogleForm()
    {
        //Web�Ƀt�H�[���f�[�^�𑗂邽�߂̃N���X
        WWWForm form = new WWWForm();

        //�t�H�[���̃t�B�[���h�ɑ΂��A�e�L�X�g�̕������R�Â���
        //AddField(key, value)
        form.AddField(titleEntryID, titleInput.text);
        form.AddField(messageEntryID, messageInput.text);

        //Google�t�H�[����Post���N�G�X�g�𑗂�
        UnityWebRequest www = UnityWebRequest.Post(formUrl, form);

        //���M����������(�����̃��X�|���X���Ԃ�)����܂ňꎞ��~����
        yield return www.SendWebRequest();

        //���M�R�[�h��0���ʂ��̂̓X�e�[�^�X�R�[�h200(OK)��Ԃ��Ȃ����Ƃ����邽��
        if (www.result == UnityWebRequest.Result.Success || www.responseCode == 0)
        {
            Debug.Log("���M�����I");

            //�L�q�������e����ɂ���
            titleInput.text = "";
            messageInput.text = "";

            //form���j���[�����
            if (formMenu != null)
            {
                formMenu.Option_Close();
            }
            else
            {
                Debug.Log("formMenu������`�ł��I");
            }

            //Thank you�ƕ\������
            SuccessPanel.SetActive(true);
            //��莞�Ԍ�ɏ�����l�ɂ���
            StartCoroutine(HideSuccessPanelAfterSeconds(2f));

        }
        else
        {
            Debug.Log("���M���s: " + www.error);
        }
    }

    //Thank you���B������
    IEnumerator HideSuccessPanelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SuccessPanel.SetActive(false);
    }
}
