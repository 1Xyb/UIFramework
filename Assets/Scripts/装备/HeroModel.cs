using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeroModel : Modelbase
{
    //装备栏数据集合
    Dictionary<int, Inventory> dicequip = new Dictionary<int, Inventory>();
    //背包数据集合
    public  List<Inventory> bagList = new List<Inventory>();
    //背包格子数量
    public int bagnum;
    public Inventory startdata, enddata,xzdata;
    //角色初始HP  POWER  没装备时
    public int hp_start=200, power_start=200;
    public int hp_end, power_end;//穿戴装备后总量
    public int hpnum, powernum;

    public void AddBag(Inventory data)
    {
        for (int i = 0; i < bagList.Count; i++)
        {
            if (bagList[i].id != data.id)
            {
                bagList.Add(data);
                return;
            }
        }
        //发消息更新UI
        MessageManager.Instance.OnDisPatch(333);
    }

    public void RemoveDicequip()
    {
        if (xzdata.equipType == "头部")
        {
            dicequip[0] = new Inventory();
        }
        if (xzdata.equipType == "衣服")
        {
            dicequip[1] = new Inventory();
        }
        if (xzdata.equipType == "鞋子")
        {
            dicequip[2] = new Inventory();
        }
        if (xzdata.equipType == "武器")
        {
            dicequip[3] = new Inventory();
        }
        if (xzdata.equipType == "翅膀")
        {
            dicequip[4] = new Inventory();
        }
        if (xzdata.equipType == "手镯")
        {
            dicequip[5] = new Inventory();
        }
        if (xzdata.equipType == "戒指")
        {
            dicequip[6] = new Inventory();
        }
        if (xzdata.equipType == "项链")
        {
            dicequip[7] = new Inventory();
        }
        SumAllData();//重新计算总战力和血量
        MessageManager.Instance.OnDisPatch(4444, hp_start, power_start);
    }

    int index = 0;
    Sequence sequence;
    public override void LoadModel()
    {
        bagnum = 20;
        //初始化装备栏数据
        for (int i = 0; i < 8; i++)
        {
            Inventory data = new Inventory();
            dicequip.Add(i, data);
        }
        //初始化背包数据
        for (int i = 0; i < 5; i++)
        {
            bagList.Add(ConfigManager.Instance.configTable_Inventory.Table[i]);
        }

        base.LoadModel();
    }
    public void RemoveBagData(int id)
    {
        for (int i = 0; i < bagList.Count; i++)
        {
            if (bagList[i].id == id)
            {
                bagList.RemoveAt(i);
            }
        }
        //发消息更新UI
        MessageManager.Instance.OnDisPatch(333);
    }
    public void AddDicequip()
    {
        if (startdata.equipType == "头部")
        {
            dicequip[0] = startdata;
        }
        if (startdata.equipType == "衣服")
        {
            dicequip[1] = startdata;
        }
        if (startdata.equipType == "鞋子")
        {
            dicequip[2] = startdata;
        }
        if (startdata.equipType == "武器")
        {
            dicequip[3] = startdata;
        }
        if (startdata.equipType == "翅膀")
        {
            dicequip[4] = startdata;
        }
        if (startdata.equipType == "手镯")
        {
            dicequip[5] = startdata;
        }
        if (startdata.equipType == "戒指")
        {
            dicequip[6] = startdata;
        }
        if (startdata.equipType == "项链")
        {
            dicequip[7] = startdata;
        }
        hp_start = 200;
        power_start = 200;
        SumAllData();
        //消息中心发送更新UI的战斗力血量等信息
        MessageManager.Instance.OnDisPatch(444, hp_start, power_start);
    }

    internal void ChangeDicequip(Inventory data1,Inventory data2)
    {
        if (startdata.equipType == "头部")
        {
            dicequip[0] = data1;
        }
        if (startdata.equipType == "衣服")
        {
            dicequip[1] = data1;
        }
        if (startdata.equipType == "鞋子")
        {
            dicequip[2] = data1;
        }
        if (startdata.equipType == "武器")
        {
            dicequip[3] = data1;
        }
        if (startdata.equipType == "翅膀")
        {
            dicequip[4] = data1;
        }
        if (startdata.equipType == "手镯")
        {
            dicequip[5] = data1;
        }
        if (startdata.equipType == "戒指")
        {
            dicequip[6] = data1;
        }
        if (startdata.equipType == "项链")
        {
            dicequip[7] = data1;
        }
        SumAllData();//交换装备数据重新计算
        MessageManager.Instance.OnDisPatch(44444, hp_start, power_start);
    }

    //数字滚动
    public void ShowNum(int hpnum, int hp_end, Text hp)
    {
        sequence.Append(DOTween.To(delegate (float x)
        {
            hp.text = x.ToString("0");
        }, hpnum, hp_end, 1));
    }


    //计算总战力
    public void SumAllData()
     {
        hp_start = 200;
        power_start = 200;
        //遍历字典算出总战力
        for (int i = 0; i < dicequip.Count; i++)
        {
            var j = i;
            if (dicequip[j].hp != null)
            {
                hp_start += int.Parse(dicequip[j].hp);
                hp_end = hp_start;
                power_start += int.Parse(dicequip[j].power);
                power_end = power_start;
                hpnum = hp_end - int.Parse(dicequip[j].hp);
                powernum = power_end - int.Parse(dicequip[j].power);
            }
        }
        //isok = true;
        index++;
    }
}
