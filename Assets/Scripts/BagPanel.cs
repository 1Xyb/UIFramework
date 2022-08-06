using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BagPanel : UIbase
{
    bool isclose;
    public Button close_btn;
    public Transform content;
    public override void Init()
    {
        MessageManager.Instance.OnAddListen(1, ShowDate);
        close_btn.onClick.AddListener(() =>
        {   
                UIManager.Instance.CloseUI(PanelName.BagPanel);
        });
        for (int i = 0; i < ModelManager.Instance.getmodel<BagModel>(). boxnum; i++)
        {
            GameObject clone = Instantiate(ResManager.Instance.Load<GameObject>(FileName.UIitem,"bagitem"), content, false);
            list.Add(clone);
        }
        ShowBagDate();
        this.transform.localScale = Vector3.zero;
        base.Init();
    }

    private void ShowDate(object obj)
    { 
        ShowBagDate();
    }
    public List<GameObject> list = new List<GameObject>();
    public void ShowBagDate()
    {
        //for (int i = 0; i < content.childCount; i++)
        //{
        //    Destroy(content.GetChild(i).gameObject);
        //}
        //for (int i = 0; i < BagModel.Instance.bagdatas.Count; i++)
        //{
        //    GameObject clone = Instantiate(Resources.Load<GameObject>("bagitem"), content, false);
        //    clone.GetComponent<Bagitem>().Init(BagModel.Instance.bagdatas[i]);
        //}

        //for (int i = 0; i < list.Count; i++)
        //{
        //    if (i < ModelManager.Instance.getmodel<BagModel>().bagdatas.Count)
        //    {
        //        list[i].GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().bagdatas[i]);
        //    }
        //}
    }
    //¶¯»­
    public override void Show()
    {
        this.transform.DOScale(Vector3.one, 2);
        base.Show();
    }
    public override void Hide()
    {
        this.transform.DOScale(Vector3.zero, 2).OnComplete(()=> { });
    }
}
