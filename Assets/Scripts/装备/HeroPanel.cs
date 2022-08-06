using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroPanel : UIbase
{
    public Transform content;
    public static List<GameObject> allbox = new List<GameObject>();
    HeroModel hero;
    public Text hp_text, power_text;
    public Button clost_btn;
    public override void Init()
    {
        MessageManager.Instance.OnAddListen(333, RefushiUI);
        hero = ModelManager.Instance.getmodel<HeroModel>();
        ShowNullBox();
        ShowBagData();
        hp_text.text = "HP："+hero.hp_start.ToString();
        power_text.text = "力量：" + hero.power_start.ToString();
        base.Init();
        clost_btn.onClick.AddListener(() =>
        {
            UIManager.Instance.CloseUI(PanelName.BagPanel);
            UIManager.Instance.OpenUI(PanelName.MainPanel);
        });
    }
    /// <summary>
    /// 打开面板的时候就监听消息
    /// </summary>
    public override void Show()
    {
        MessageManager.Instance.OnAddListen(555, DoubleTipsCall);
        MessageManager.Instance.OnAddListen(444, HPPower);
        MessageManager.Instance.OnAddListen(4444, HPPower2);
        MessageManager.Instance.OnAddListen(44444, HPPower3);
        base.Show();
    }

    private void HPPower3(object obj)
    {
        object[] arr = obj as object[];
        int hp = int.Parse(arr[0].ToString());
        int power = int.Parse(arr[1].ToString());
        hp_text.text = hp.ToString();
        power_text.text = power.ToString();
        //hero.ShowNum(hero.hp_end, hp, hp_text);
        //hero.ShowNum(hero.power_end, power, power_text);
    }

    private void HPPower2(object obj)
    {
        object[] arr = obj as object[];
        int hp = int.Parse(arr[0].ToString());
        int power = int.Parse(arr[1].ToString());
        hp_text.text = hp.ToString();
        power_text.text = power.ToString();
        hero.ShowNum((hero.hp_end + int.Parse(hero.xzdata.hp)), hp, hp_text);
        hero.ShowNum((hero.power_end + int.Parse(hero.xzdata.power)), power, power_text);
    }

    private void HPPower(object obj)
    {
        object[] arr = obj as object[];
        int hp = int.Parse(arr[0].ToString());
        int power = int.Parse(arr[1].ToString());
        hp_text.text =  hp.ToString();
        power_text.text =  power.ToString();
        hero.ShowNum(hero.hpnum, hero.hp_end, hp_text);
        hero.ShowNum(hero.powernum, hero.power_end, power_text);
    }

    private void DoubleTipsCall(object obj)
    {
        object[] arr = obj as object[];
        bool isok = (bool)arr[0];
        if (isok)
        {
            //调用model层销毁数据的方法
            hero.RemoveBagData(hero.startdata.id);
            //关闭面板
            UIManager.Instance.CloseUI(PanelName.TipsPanel);
        }
        else
        {
            UIManager.Instance.CloseUI(PanelName.TipsPanel);
        }
    }

    /// <summary>
    /// 更新背包数据
    /// </summary>
    /// <param name="obj"></param>
    private void RefushiUI(object obj)
    {
        ShowBagData();
    }

    private void ShowBagData()
    {
        for (int i = 0; i < allbox.Count; i++)
        {
            allbox[i].GetComponent<Bagitem>().ClearData();
        }
        for (int i = 0; i < allbox.Count; i++)
        {
            if (i < hero.bagList.Count)
            {
                allbox[i].GetComponent<Bagitem>().InitData(hero.bagList[i]);
            }
        }
    }

    private void ShowNullBox()
    {
        for (int i = 0; i < hero.bagnum; i++)
        {
            GameObject gezi = Instantiate(Resources.Load<GameObject>("UIitem/bagitem"),content,false);
            allbox.Add(gezi);
        }
    }
}
