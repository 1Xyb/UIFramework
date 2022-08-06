using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelName
{
    MainPanel, ShopPanel, BagPanel, TipsPanel,PMHPanel, PMPanel, MyPmPanel
}
public enum PanelType
{
    fix, normal, huchi, layer
}
public class UIManager : Singleton<UIManager>
{
    Dictionary<PanelName, UIbase> uidic = new Dictionary<PanelName, UIbase>();
    Dictionary<PanelName, UIbase> uicachedic = new Dictionary<PanelName, UIbase>();
    Stack<UIbase> uistack = new Stack<UIbase>();
    private Canvas can;
    public Canvas Can
    {
        get { return can; }
    }
    private Camera cam;
    public Camera Cam
    {
        get { return cam; }
    }
    public UIManager()
    {
        can = GameObject.FindObjectOfType<Canvas>();
        cam = GameObject.Find("UICamera").GetComponent<Camera>();
    }
    public void CloseAllPanel()
    {
        foreach (var item in uidic.Values)
        {
            item.Hide();
        }
    }
    public void OpenUI(PanelName name)
    {
        UIbase temp = LoadUIbase(name);
        switch (temp.type)
        {
            case PanelType.fix:
                temp.Show();
                break;
            case PanelType.normal:
                if (!uicachedic.ContainsKey(name))
                {
                    uicachedic.Add(name, temp);
                }
                temp.Show();
                break;
            case PanelType.huchi:
                foreach (var item in uicachedic.Values)
                {
                    item.Hide();
                }
                break;
            case PanelType.layer:
                if (!uistack.Contains(temp))
                {
                    uistack.Push(temp);
                }
                temp.transform.SetAsLastSibling();
                break;

        }
    }
    public void CloseUI(PanelName name)
    {
        switch (uidic[name].type)
        {
            case PanelType.fix:
                uidic[name].Hide();
                break;
            case PanelType.normal:
                if (uicachedic.ContainsKey(name))
                {
                    uicachedic[name].Hide();
                    uicachedic.Remove(name);
                }
                break;
            case PanelType.huchi:
                foreach (var item in uicachedic.Values)
                {
                    item.Show();
                }
                break;
            case PanelType.layer:
                CloseStake();
                break;
        }
    }

    private void CloseStake()
    {
        if (uistack.Count >0)
        {
            UIbase temp = uistack.Pop();
            temp.Hide();
        }
    }

    private UIbase LoadUIbase(PanelName name)
    {
        UIbase temp;
        if(uidic.TryGetValue(name,out temp))
        {
            Debug.Log("第N次打开" + name.ToString());
            return temp;
        }
        else
        {
            //GameObject res = Resources.Load<GameObject>(name.ToString());
            GameObject res = ResManager.Instance.Load<GameObject>(FileName.UIPanel, name.ToString());
            if (res == null)
            {
                Debug.Log("要加载的预制体名字错误或者路径错误");
            }
            else
            {
                GameObject clone = GameObject.Instantiate(res, can.transform, false);
                temp = clone.GetComponent<UIbase>();
                if (temp == null)
                {
                    Debug.Log("实例的面板没有继承UIbase或者没有脚本");
                }
                else
                {
                    uidic.Add(name, temp);
                    temp.Init();
                }
            }
        }
        return temp;
    }
}
