using System.Collections;//コルーチン(一時中断機能をもつ構造)を使うため
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;//web通信機能を持つ
using TMPro;//TextMeshProのInputFieldを使うため

public class GoogleformSubmitter : MonoBehaviour
{
    //送信する内容と紐づけるテキスト達
    public TMP_InputField titleInput;   //問い合わせ内容
    public TMP_InputField messageInput; //問い合わせ詳細

    // Googleフォームの送信先URL(直接ポスト用のURL)(/viewから変換する必要がある)
    private string formUrl = "https://docs.google.com/forms/d/e/1FAIpQLSeVaEg426qtw94aHgLccIm-rjg0Vg9q9-5TD-_MS7iO8Rs6lg/formResponse";

    // 各フィールドの entry.ID（Googleフォームの開発者ツールから調べたもの）
    private string titleEntryID = "entry.1826561722";
    private string messageEntryID = "entry.1038773362";

    public OptionMenu formMenu;
    public GameObject SuccessPanel;

    private void Start()
    {
        SuccessPanel.SetActive(false);
    }
    //Onclickに貼り付ける用
    public void OnSubmit()
    {
        StartCoroutine(PostToGoogleForm());
    }

    //書くのをキャンセルしたい場合
    public void Cancel()
    {
        //記述した内容を空にする
        titleInput.text = "";
        messageInput.text = "";

        //formメニューを閉じる
        if (formMenu != null)
        {
            formMenu.Option_Close();
        }
        else
        {
            Debug.Log("formMenuが未定義です！");
        }
    }

    //送信処理
    IEnumerator PostToGoogleForm()
    {
        //Webにフォームデータを送るためのクラス
        WWWForm form = new WWWForm();

        //フォームのフィールドに対し、テキストの文字列を紐づける
        //AddField(key, value)
        form.AddField(titleEntryID, titleInput.text);
        form.AddField(messageEntryID, messageInput.text);

        //GoogleフォームへPostリクエストを送る
        UnityWebRequest www = UnityWebRequest.Post(formUrl, form);

        //送信処理が完了(完了のレスポンスが返る)するまで一時停止する
        yield return www.SendWebRequest();

        //送信コードが0も通すのはステータスコード200(OK)を返さないことがあるため
        if (www.result == UnityWebRequest.Result.Success || www.responseCode == 0)
        {
            Debug.Log("送信成功！");

            //記述した内容を空にする
            titleInput.text = "";
            messageInput.text = "";

            //formメニューを閉じる
            if (formMenu != null)
            {
                formMenu.Option_Close();
            }
            else
            {
                Debug.Log("formMenuが未定義です！");
            }

            //Thank youと表示する
            SuccessPanel.SetActive(true);
            //一定時間後に消える様にする
            StartCoroutine(HideSuccessPanelAfterSeconds(2f));

        }
        else
        {
            Debug.Log("送信失敗: " + www.error);
        }
    }

    //Thank youを隠す処理
    IEnumerator HideSuccessPanelAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SuccessPanel.SetActive(false);
    }
}
