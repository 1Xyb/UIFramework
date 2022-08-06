using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopitem : MonoBehaviour
{
    public Image icon;
    public Text t_name;
    public Button buy_btn;
    public Image img_hot, img_xl;
    public void Init(ShopModel.ShopDate date)
    {
        //icon.sprite = Resources.Load<Sprite>("icon/" + date.inventory.icon);
        icon.sprite = ResManager.Instance.Load<Sprite>(FileName.icon, date.inventory.icon);
        t_name.text = date.inventory.name;
        buy_btn.onClick.AddListener(() =>
        {
            ModelManager.Instance.getmodel<BagModel>().AddBagDate(int.Parse(date.inventory.id), 1);
           
        });
        img_hot.gameObject.SetActive(date.ishot);
        img_xl.gameObject.SetActive(date.iszk);
    }
}
