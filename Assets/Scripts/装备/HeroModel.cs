using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeroModel : Modelbase
{
    //װ�������ݼ���
    Dictionary<int, Inventory> dicequip = new Dictionary<int, Inventory>();
    //�������ݼ���
    public  List<Inventory> bagList = new List<Inventory>();
    //������������
    public int bagnum;
    public Inventory startdata, enddata,xzdata;
    //��ɫ��ʼHP  POWER  ûװ��ʱ
    public int hp_start=200, power_start=200;
    public int hp_end, power_end;//����װ��������
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
        //����Ϣ����UI
        MessageManager.Instance.OnDisPatch(333);
    }

    public void RemoveDicequip()
    {
        if (xzdata.equipType == "ͷ��")
        {
            dicequip[0] = new Inventory();
        }
        if (xzdata.equipType == "�·�")
        {
            dicequip[1] = new Inventory();
        }
        if (xzdata.equipType == "Ь��")
        {
            dicequip[2] = new Inventory();
        }
        if (xzdata.equipType == "����")
        {
            dicequip[3] = new Inventory();
        }
        if (xzdata.equipType == "���")
        {
            dicequip[4] = new Inventory();
        }
        if (xzdata.equipType == "����")
        {
            dicequip[5] = new Inventory();
        }
        if (xzdata.equipType == "��ָ")
        {
            dicequip[6] = new Inventory();
        }
        if (xzdata.equipType == "����")
        {
            dicequip[7] = new Inventory();
        }
        SumAllData();//���¼�����ս����Ѫ��
        MessageManager.Instance.OnDisPatch(4444, hp_start, power_start);
    }

    int index = 0;
    Sequence sequence;
    public override void LoadModel()
    {
        bagnum = 20;
        //��ʼ��װ��������
        for (int i = 0; i < 8; i++)
        {
            Inventory data = new Inventory();
            dicequip.Add(i, data);
        }
        //��ʼ����������
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
        //����Ϣ����UI
        MessageManager.Instance.OnDisPatch(333);
    }
    public void AddDicequip()
    {
        if (startdata.equipType == "ͷ��")
        {
            dicequip[0] = startdata;
        }
        if (startdata.equipType == "�·�")
        {
            dicequip[1] = startdata;
        }
        if (startdata.equipType == "Ь��")
        {
            dicequip[2] = startdata;
        }
        if (startdata.equipType == "����")
        {
            dicequip[3] = startdata;
        }
        if (startdata.equipType == "���")
        {
            dicequip[4] = startdata;
        }
        if (startdata.equipType == "����")
        {
            dicequip[5] = startdata;
        }
        if (startdata.equipType == "��ָ")
        {
            dicequip[6] = startdata;
        }
        if (startdata.equipType == "����")
        {
            dicequip[7] = startdata;
        }
        hp_start = 200;
        power_start = 200;
        SumAllData();
        //��Ϣ���ķ��͸���UI��ս����Ѫ������Ϣ
        MessageManager.Instance.OnDisPatch(444, hp_start, power_start);
    }

    internal void ChangeDicequip(Inventory data1,Inventory data2)
    {
        if (startdata.equipType == "ͷ��")
        {
            dicequip[0] = data1;
        }
        if (startdata.equipType == "�·�")
        {
            dicequip[1] = data1;
        }
        if (startdata.equipType == "Ь��")
        {
            dicequip[2] = data1;
        }
        if (startdata.equipType == "����")
        {
            dicequip[3] = data1;
        }
        if (startdata.equipType == "���")
        {
            dicequip[4] = data1;
        }
        if (startdata.equipType == "����")
        {
            dicequip[5] = data1;
        }
        if (startdata.equipType == "��ָ")
        {
            dicequip[6] = data1;
        }
        if (startdata.equipType == "����")
        {
            dicequip[7] = data1;
        }
        SumAllData();//����װ���������¼���
        MessageManager.Instance.OnDisPatch(44444, hp_start, power_start);
    }

    //���ֹ���
    public void ShowNum(int hpnum, int hp_end, Text hp)
    {
        sequence.Append(DOTween.To(delegate (float x)
        {
            hp.text = x.ToString("0");
        }, hpnum, hp_end, 1));
    }


    //������ս��
    public void SumAllData()
     {
        hp_start = 200;
        power_start = 200;
        //�����ֵ������ս��
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
