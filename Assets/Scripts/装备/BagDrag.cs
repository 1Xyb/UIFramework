using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    HeroModel hero;
    GameObject tempdrag;
    private void Start()
    {
        hero = ModelManager.Instance.getmodel<HeroModel>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //确保鼠标拖动的物体是装备
        if (eventData.pointerEnter.gameObject.GetComponent<Bagitem>() != null)
        {
            tempdrag = new GameObject();
            tempdrag.transform.SetParent(UIManager.Instance.Can.transform,false);//设置父级取消父级影响
            Image ima = tempdrag.AddComponent<Image>();
            ima.raycastTarget = false;
            hero.startdata = eventData.pointerEnter.GetComponent<Bagitem>().MyData_Inventory;
            ima.sprite = Resources.Load<Sprite>("icon/" + hero.startdata.icon);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (tempdrag != null)
        {
            Vector3 wp;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(tempdrag.GetComponent<RectTransform>(), Input.mousePosition, UIManager.Instance.Cam, out wp);
            tempdrag.transform.position = wp;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {  
        if (eventData.pointerEnter == null || eventData.pointerEnter.GetComponent<Bagitem>() == null)
        {
            UIManager.Instance.OpenUI(PanelName.TipsPanel);
            //发消息  
            MessageManager.Instance.OnDisPatch(222, "提示", "是否销毁" + hero.startdata.name, 2);
            Destroy(tempdrag);
            return;
        }
        if (tempdrag == null)
        {
            return;
        }
        hero.enddata = eventData.pointerEnter.GetComponent<Bagitem>().MyData_Inventory;
        if (hero.enddata == null)//放到空格子
        {
            //放到空格子  两种情况 1：背包内自己交换  2：背包到装备栏
            if (eventData.pointerEnter.tag == hero.startdata.equipType)//背包到装备栏
            {
                //ui界面的显示
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                //gameObject.GetComponent<Bagitem>().ClearData();背包数据持续更新
                //背包到装备栏  数据要同步
                hero.RemoveBagData(hero.startdata.id);//背包移除
                
                hero.AddDicequip();//装备栏添加
                
            }
            else if (eventData.pointerEnter.tag == "背包")//背包内部交换
            {
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().ClearData();
            }
            else
            {
                MessageManager.Instance.OnDisPatch(111, "提示", "装备类型不符", 1);
                UIManager.Instance.OpenUI(PanelName.TipsPanel);
            }
        }
        else//两个数据交换
        {
            //  两种情况 1：背包内自己交换  2：背包到装备栏
            if (eventData.pointerEnter.tag == hero.startdata.equipType)//背包到装备栏
            {
                //ui界面的显示
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().InitData(hero.enddata);
                //背包到装备栏  数据要同步
                hero.ChangeDicequip(hero.startdata,hero.enddata);
            }
            else if (eventData.pointerEnter.tag == "背包")//背包内部交换
            {
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().InitData(hero.enddata);
                
                //hero.SumAllData();
            }
            else
            {
                MessageManager.Instance.OnDisPatch(111, "提示", "装备类型不符", 1);
                UIManager.Instance.OpenUI(PanelName.TipsPanel);
                Debug.Log("装备类型不符");
            }
        }
        Destroy(tempdrag);
    }
}
