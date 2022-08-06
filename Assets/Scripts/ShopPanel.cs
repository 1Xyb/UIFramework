using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : UIbase
{
    public Button close_btn;
    public Transform content;
    public override void Init()
    {
        //ModelManager.Instance.getmodel<ShopModel>().InitShopmodel();
       
        close_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUI(PanelName.ShopPanel); 
        });
        ShowShopDate();
        
        base.Init();
    }

    private void ShowShopDate()
    {
        for (int i = 0; i < ModelManager.Instance.getmodel<ShopModel>().shopDates.Count; i++)
        {
            //GameObject clone = Instantiate(Resources.Load<GameObject>("shopitem"),content,false);
            GameObject clone = Instantiate(ResManager.Instance.Load<GameObject>(FileName.UIitem,"shopitem"),content,false);
            clone.GetComponent<Shopitem>().Init(ModelManager.Instance.getmodel<ShopModel>().shopDates[i]);
        }
    }
}
