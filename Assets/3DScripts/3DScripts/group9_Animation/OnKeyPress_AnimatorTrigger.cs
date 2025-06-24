using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// あるキーを押したら、トリガー発生
public class OnKeyPress_AnimatorTrigger : MonoBehaviour
{
	public string pushKey = "space";	// キー：Inspectorで指定
	public string triggerName = "";		// trigger名：Inspectorで指定

	bool pushFlag = false;          // キーを押しっぱなしかどうか
	public int Cooltimer = 0;

	void Update()
	{
		if (Input.GetKey(pushKey)) // もし、キーが押されて
		{
			if (Cooltimer == 0 || pushFlag == false) // 押しっぱなしでなければ
			{
				Cooltimer = 10;
				pushFlag = true; // 押した状態に
				// アニメーターのトリガー発生
				Animator m_Animator = gameObject.GetComponent<Animator>();
				m_Animator.SetTrigger(triggerName);
			}
		} else
		{
			pushFlag = false; 		// 押した状態解除
		}
		Cooltimer -= 1;
	}
}
