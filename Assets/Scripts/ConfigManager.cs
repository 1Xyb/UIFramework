using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// 配置表管理类
/// 所有配置表都在这里解析 你可以用它调用任意一个配置表
/// </summary>
public class ConfigManager : Singleton<ConfigManager>
{

    public readonly ConfigTable<HeroConfig> configTable_HERO = new ConfigTable<HeroConfig>();
    public readonly ConfigTable<WzryConfig> configTable_WZRY = new ConfigTable<WzryConfig>();
    public readonly ConfigTable<Inventory> configTable_Inventory = new ConfigTable<Inventory>();
    /// <summary>
    /// 公开的 提供给游戏入口使用
    /// </summary>
    public void ParseAllConfig() 
    {
        ParseWZRY();
        Parsehero();
        ParseInventory();
    }

    private void ParseInventory()
    {
        string info = ResManager.Instance.Load<TextAsset>(FileName.config, "inventoryConfig").text;
        configTable_Inventory.Table = JsonConvert.DeserializeObject<List<Inventory>>(info);
    }

    private void Parsehero()
    {
        string info = ResManager.Instance.Load<TextAsset>(FileName.config, "Hero1").text;
        XmlDocument xd = new XmlDocument();
        //读取文件路径
        xd.Load(Application.dataPath + "/Resources/config/Hero1.xml");
        //读取内容
        //xd.LoadXml(info);
        XmlNodeList nodeList = xd.SelectNodes("//Hero");
        foreach (XmlElement item in nodeList)
        {
            HeroConfig data = new HeroConfig();
            data.ParseXml(item);
            configTable_HERO.Table.Add(data);
        }
    }

    public void ParseWZRY()
    {
        string info = ResManager.Instance.Load<TextAsset>(FileName.config, "wzry").text;
        XmlDocument xd = new XmlDocument();
        xd.LoadXml(info);
        XmlNodeList nodeList = xd.SelectNodes("//hero");
        foreach (XmlElement item in nodeList)
        {
            WzryConfig data = new WzryConfig();
            data.ParseXml(item, true);
            configTable_WZRY.Table.Add(data);
        }
    }
}
public class Inventory:ConfigBase
{
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
//继承
public class HeroConfig:ConfigBase
{
    public string name;
    public override void ParseXml(XmlElement xe, bool isinertxt = false)
    {
        name = xe["name"].InnerText;
        base.ParseXml(xe, isinertxt);
    }
}
public class WzryConfig : ConfigBase
{
    public string name;
    public override void ParseXml(XmlElement xe, bool isinertxt = false)
    {
        base.ParseXml(xe, isinertxt);
        name = xe.GetAttribute("name");
    }
}