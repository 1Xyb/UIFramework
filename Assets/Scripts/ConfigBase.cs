using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

/// <summary>
/// �������ñ�Ļ���
/// ��ȡ���е����Ի��߷���
/// csv json xmlx text
/// </summary>
public class ConfigBase
{
    public int id;//��������
    public virtual void ParseCsv(string data)
    {
        id = int.Parse(data.Split(',')[0]);
    }
    public virtual void ParseJson()
    {
        //newtonsoftjson  �ײ��Ѿ��������  ���Բ�����
    }
    public virtual void ParseXml(XmlElement xe,bool isinertxt = false)
    {
        if (isinertxt)
        {
            //��������
            id = int.Parse(xe.GetAttribute("id"));
        }
        else
        {
            //���� inntext
            id = int.Parse(xe["id"].InnerText);
        }
    }
}
