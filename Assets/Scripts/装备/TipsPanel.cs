using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsPanel : UIbase
{
    public Button ok_btn, cancle_btn;
    public Text tips_text, t;
    public override void Init()
    {
        MessageManager.Instance.OnAddListen(222,ShowCallBack);
        MessageManager.Instance.OnAddListen(111,ShowCallBack);
        ok_btn.onClick.AddListener(() =>
        {
            MessageManager.Instance.OnDisPatch(555, true);
        });
        cancle_btn.onClick.AddListener(() =>
        {
            MessageManager.Instance.OnDisPatch(555, false);
        });
        base.Init();
    }
    private void ShowCallBack(object obj)
    {
        object[] arr = obj as object[];
        tips_text.text = arr[0].ToString();
        t.text = arr[1].ToString();
        int num = int.Parse(arr[2].ToString());
        if (num == 1)
        {
            ok_btn.gameObject.SetActive(false);
        }
        else
        {
            ok_btn.gameObject.SetActive(true);
        }
    }
}
