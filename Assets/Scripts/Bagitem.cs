using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bagitem : MonoBehaviour
{
    public Image icon;
    public Text num;
    //private BagModel.Bagdate mydata;
    //public BagModel.Bagdate Mydata
    //{
    //    get { return mydata; }
    //}
    //public void Init(BagModel.Bagdate date)
    //{
    //    //直接缓存
    //    mydata = date;
    //    icon.sprite = Resources.Load<Sprite>("icon/" + date.inventory.icon);
    //    num.text = date.num.ToString();
    //}
    public Inventory xzdata;
    private Inventory mydata_inventory;
    public Inventory MyData_Inventory
    {
        get { return mydata_inventory; }
    }
    public void InitData(Inventory data)
    {
        mydata_inventory = data;
        xzdata = data;
        icon.sprite = Resources.Load<Sprite>("icon/" + data.icon);
    }
    public void ClearData()
    {
        mydata_inventory = null;
        icon.sprite = Resources.Load<Sprite>("icon/bg_道具");
    }
    ///// <summary>
    ///// 物品和空交换
    ///// </summary>
    //public void ClearDate()
    //{
    //    mydata = null;
    //    icon.sprite = Resources.Load<Sprite>("icon/bg_道具");
    //    num.text = "";
    //}
}
