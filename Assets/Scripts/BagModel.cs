using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagModel : Modelbase
{
    public class Bagdate
    {
        public int num;
        public ShopModel.Inventory inventory;
    }
    public readonly List<Bagdate> bagdatas = new List<Bagdate>();
    public void AddBagDate(int id,int num)
    {
        if (bagdatas.Count == 0)
        {
            Bagdate date = new Bagdate(); 
            date.inventory=ModelManager.Instance.getmodel<ShopModel>().inventories.Find((x)=>int.Parse(x.id)==id);
            date.num = num;
            bagdatas.Add(date);
            MessageManager.Instance.OnDisPatch(1, bagdatas);

            return;
        }
        bool ishave = false;
        for (int i = 0; i < bagdatas.Count; i++)
        {
            if (int.Parse(bagdatas[i].inventory.id) == id)
            {
                bagdatas[i].num += num;
                ishave = true;
            }
        }
        if (!ishave)
        {
            Bagdate date = new Bagdate();
            date.inventory = ModelManager.Instance.getmodel<ShopModel>(). inventories.Find((x) => int.Parse(x.id) == id);
            date.num = num;
            bagdatas.Add(date);
        }
        MessageManager.Instance.OnDisPatch(1, bagdatas);
    }
    //背包格子
    public int boxnum;
    public Bagdate start_data, end_data;//交换的两个物体
    /// <summary>
    /// 新手物品
    /// </summary>
    //public void LoadModel()
    //{
    //    boxnum = 10;
    //    for (int i = 117; i < 120; i++)
    //    {
    //        Bagdate data = new Bagdate();
    //        data.inventory = ModelManager.Instance.getmodel<ShopModel>(). inventories.Find((x) => (int.Parse(x.id) == i));
    //        data.num = 2;
    //        bagdatas.Add(data);
    //    }
    //}

    public override void LoadModel()
    {
            boxnum = 10;
            for (int i = 117; i < 120; i++)
            {
                Bagdate data = new Bagdate();
                data.inventory = ModelManager.Instance.getmodel<ShopModel>().inventories.Find((x) => (int.Parse(x.id) == i));
                data.num = 2;
                bagdatas.Add(data);
            }
        base.LoadModel();
    }
    //新手随机不重复初始装备  cuowu 
    public void LoadModel1()
    {
        List<int> xs = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            int num = Random.Range(0, ModelManager.Instance.getmodel<ShopModel>().shopDates.Count);
            if (xs.Contains(num))
            {
                i--;
            }
            else
            {
                xs.Add(num);
            }
        }
        for (int i = 0; i < xs.Count; i++)
        {
            Bagdate data = new Bagdate();
            data.inventory = ModelManager.Instance.getmodel<ShopModel>(). inventories.Find((x) => (int.Parse(x.id) == (int.Parse(ModelManager.Instance.getmodel<ShopModel>().shopDates[xs[i]].inventory.id))));
            data.num = 2;
            bagdatas.Add(data);
        }
    }
}
