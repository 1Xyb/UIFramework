using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// 所有配置表的基类
/// 提取共有的属性或者方法
/// csv json xmlx text
/// </summary>
public class ConfigBase
{
    public int id;//共有属性
    public virtual void ParseCsv(string data)
    {
        id = int.Parse(data.Split(',')[0]);
    }
    public virtual void ParseJson()
    {
        //newtonsoftjson  底层已经解析完毕  所以不处理
    }
    public virtual void ParseXml(XmlElement xe,bool isinertxt = false)
    {
        if (isinertxt)
        {
            //解析属性
            id = int.Parse(xe.GetAttribute("id"));
        }
        else
        {
            //解析 inntext
            id = int.Parse(xe["id"].InnerText);
        }
    }
}
