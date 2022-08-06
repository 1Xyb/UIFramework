using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 拖拽脚本  给每个格子
/// </summary>
public class DradBagitem : MonoBehaviour//,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    //GameObject dragtemp;
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    //缓存拖拽的数据       起始数据
    //    ModelManager.Instance.getmodel<BagModel>().start_data = eventData.pointerEnter.GetComponent<Bagitem>().Mydata;
    //    //实例一个图片，将起始数据的图片赋值到实例的这个图片
    //    dragtemp = Instantiate(Resources.Load<GameObject>("dragtemp"), UIManager.Instance.Can.transform, false);
    //    dragtemp.GetComponent<Image>().sprite = ResManager.Instance.Load<Sprite>(FileName.icon, ModelManager.Instance.getmodel<BagModel>().start_data.inventory.icon);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    dragtemp.transform.position = Input.mousePosition;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    //记录拖拽结束的数据 结束数据
    //    ModelManager.Instance.getmodel<BagModel>().end_data = eventData.pointerEnter.GetComponent<Bagitem>().Mydata;
    //    //把结束点的数据换成起始点的数据   把起始数据换成结束数据
    //    if(ModelManager.Instance.getmodel<BagModel>().end_data==null)//如果结束点数据为空 就是起始数据和空    空和起始数据的交换
    //    {
    //        eventData.pointerEnter.gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().start_data);
    //        gameObject.GetComponent<Bagitem>().ClearDate();
    //    }
    //    else
    //    {
    //        eventData.pointerEnter.gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().start_data);
    //        gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().end_data);
    //    }
    //    //实例图片销毁
    //    Destroy(dragtemp);
    //}
}
