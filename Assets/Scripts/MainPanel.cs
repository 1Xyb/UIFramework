using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : UIbase
{
    public Button bag_btn, shop_btn,pm_btn;

    // Start is called before the first frame update
    void Start()
    {
        type = PanelType.huchi;
        bag_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.BagPanel);         
        });
        shop_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.ShopPanel);
        });
        pm_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.PMHPanel);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
