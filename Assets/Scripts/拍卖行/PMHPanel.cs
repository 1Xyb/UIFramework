using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PMHPanel : UIbase
{
    public Button pm_btn, my_btn, close_btn;
    public override void Init()
    {
        pm_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.PMPanel);
            UIManager.Instance.CloseUI(PanelName.MyPmPanel);
        });
        my_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.MyPmPanel);
            UIManager.Instance.CloseUI(PanelName.PMPanel);
        });
        close_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.OpenUI(PanelName.MainPanel);
            UIManager.Instance.CloseUI(PanelName.PMHPanel);
            UIManager.Instance.CloseUI(PanelName.MyPmPanel);
            UIManager.Instance.CloseUI(PanelName.PMPanel);
        });
        base.Init();
    }
}
