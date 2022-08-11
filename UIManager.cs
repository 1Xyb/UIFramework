using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelName
{
    Null=-1,
    MainPanel,
    BagPanel,
    ShopPanel,
    Max=99
}

public enum PanelRoot
{
    Null=-1,
    Normal,
    Pop,
    Max=99
}

public enum PanelType
{
    Null=-1,
    Fix,
    Normal,
    Mutex,
    Max=99
}


public class UIManager : Singleton<UIManager>
{
    Dictionary<PanelName, UIBase> uidic = new Dictionary<PanelName, UIBase>();
    Stack<UIBase> uistack = new Stack<UIBase>();
    public Canvas cav;
    public Transform normal, pop;

    public UIManager()
    {
        cav = GameObject.Find("Canvas").GetComponent<Canvas>();
        normal = GameObject.Find("normal").transform;
        pop = GameObject.Find("pop").transform;
    }

    /// <summary>
    /// 打开UI
    /// </summary>
    /// <param name="name"></param>
    public void OpenUI(PanelName name)
    {
        UIBase temp = LoadUIBase(name);
        //判断放入根节点位置
        switch (temp.root)
        {
            case PanelRoot.Normal:
                temp.transform.SetParent(normal, false);
                break;
            case PanelRoot.Pop:
                temp.transform.SetParent(pop, false);
                break;
        }
        //根据类型打开
        switch (temp.type)
        {
            case PanelType.Fix:
                break;
            case PanelType.Normal:
                if (!uistack.Contains(temp))
                    uistack.Push(temp);
                break;
            case PanelType.Mutex:
                foreach (var item in uistack)
                {
                    item.Hide();
                }
                break;
        }
        temp.Show();
    }

    /// <summary>
    /// 加载UI
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private UIBase LoadUIBase(PanelName name)
    {
        UIBase temp;
        if(!uidic.TryGetValue(name,out temp))
        {
            GameObject res = Resources.Load<GameObject>(name.ToString());
            if (res == null)
            {
                Debug.Log("路径或名字错误");
            }
            else
            {
                GameObject clone = GameObject.Instantiate(res);
                temp = clone.GetComponent<UIBase>();
                if (temp == null)
                {
                    Debug.Log("没有挂脚本或者没有继承UIbase");
                }
                else
                {
                    uidic.Add(name, temp);//加入缓存字典
                    temp.Init();//初始化
                }
            }
        }
        return temp;
    }

    /// <summary>
    /// 关闭栈
    /// </summary>
    public void CloseStack()
    {
        if (uistack.Count > 0)
        {
            UIBase temp = uistack.Pop();
            temp.Hide();
        }
    }

    public void CloseUI(PanelName name)
    {
        switch (uidic[name].type)
        {
            case PanelType.Fix:
                break;
            case PanelType.Normal:
                CloseStack();
                break;
            case PanelType.Mutex:
                foreach (var item in uistack)
                {
                    item.Show();
                }
                uidic[name].Hide();
                break;
        }
    }
}
