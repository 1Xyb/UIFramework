using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ��ק�ű�  ��ÿ������
/// </summary>
public class DradBagitem : MonoBehaviour//,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    //GameObject dragtemp;
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    //������ק������       ��ʼ����
    //    ModelManager.Instance.getmodel<BagModel>().start_data = eventData.pointerEnter.GetComponent<Bagitem>().Mydata;
    //    //ʵ��һ��ͼƬ������ʼ���ݵ�ͼƬ��ֵ��ʵ�������ͼƬ
    //    dragtemp = Instantiate(Resources.Load<GameObject>("dragtemp"), UIManager.Instance.Can.transform, false);
    //    dragtemp.GetComponent<Image>().sprite = ResManager.Instance.Load<Sprite>(FileName.icon, ModelManager.Instance.getmodel<BagModel>().start_data.inventory.icon);
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    dragtemp.transform.position = Input.mousePosition;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    //��¼��ק���������� ��������
    //    ModelManager.Instance.getmodel<BagModel>().end_data = eventData.pointerEnter.GetComponent<Bagitem>().Mydata;
    //    //�ѽ���������ݻ�����ʼ�������   ����ʼ���ݻ��ɽ�������
    //    if(ModelManager.Instance.getmodel<BagModel>().end_data==null)//�������������Ϊ�� ������ʼ���ݺͿ�    �պ���ʼ���ݵĽ���
    //    {
    //        eventData.pointerEnter.gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().start_data);
    //        gameObject.GetComponent<Bagitem>().ClearDate();
    //    }
    //    else
    //    {
    //        eventData.pointerEnter.gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().start_data);
    //        gameObject.GetComponent<Bagitem>().Init(ModelManager.Instance.getmodel<BagModel>().end_data);
    //    }
    //    //ʵ��ͼƬ����
    //    Destroy(dragtemp);
    //}
}
