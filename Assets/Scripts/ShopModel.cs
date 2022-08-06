using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ShopModel : Modelbase
{
    public struct Inventory
    {
        public string id;
        public string name;
        public string icon;
        public string inventoryType;
        public string equipType;
        public string sale;
        public string starLevel;
        public string quality;
        public string damage;
        public string hp;
        public string power;
        public string Des;
    }
    public struct ShopDate
    {
        public Inventory inventory;
        public int num;
        public int zk;
        public bool iszk;
        public bool ishot;
    }
    public List<Inventory> inventories;
    public readonly List<ShopDate> shopDates = new List<ShopDate>();
    //public void InitShopmodel()
    //{
       
    //}

    public override void LoadModel()
    {
        ParseJson();
        CreatShopDate();
        base.LoadModel();
    }

    private void CreatShopDate()
    {
        for (int i = 0; i < 10; i++)
        {
            ShopDate date = new ShopDate();
            date.inventory = inventories[i];
            date.ishot = Random.Range(0, 2) == 0 ? true : false;
            date.iszk = Random.Range(0, 2) == 0 ? true : false;
            date.zk = Random.Range(6, 10);
            if (date.iszk) date.num = 10;
            shopDates.Add(date);
        }
    }

    private void ParseJson()
    {
        //string info = Resources.Load<TextAsset>("inventoryConfig").text;
        string info = ResManager.Instance.Load<TextAsset>(FileName.config,"inventoryConfig").text;
        inventories = JsonConvert.DeserializeObject<List<Inventory>>(info);
    }
}
