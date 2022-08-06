using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// ���ñ������
/// �������ñ���������� �����������������һ�����ñ�
/// </summary>
public class ConfigManager : Singleton<ConfigManager>
{

    public readonly ConfigTable<HeroConfig> configTable_HERO = new ConfigTable<HeroConfig>();
    public readonly ConfigTable<WzryConfig> configTable_WZRY = new ConfigTable<WzryConfig>();
    public readonly ConfigTable<Inventory> configTable_Inventory = new ConfigTable<Inventory>();
    /// <summary>
    /// ������ �ṩ����Ϸ���ʹ��
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
        //��ȡ�ļ�·��
        xd.Load(Application.dataPath + "/Resources/config/Hero1.xml");
        //��ȡ����
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
//�̳�
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