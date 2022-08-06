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
        //ȷ������϶���������װ��
        if (eventData.pointerEnter.gameObject.GetComponent<Bagitem>() != null)
        {
            tempdrag = new GameObject();
            tempdrag.transform.SetParent(UIManager.Instance.Can.transform,false);//���ø���ȡ������Ӱ��
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
            //����Ϣ  
            MessageManager.Instance.OnDisPatch(222, "��ʾ", "�Ƿ�����" + hero.startdata.name, 2);
            Destroy(tempdrag);
            return;
        }
        if (tempdrag == null)
        {
            return;
        }
        hero.enddata = eventData.pointerEnter.GetComponent<Bagitem>().MyData_Inventory;
        if (hero.enddata == null)//�ŵ��ո���
        {
            //�ŵ��ո���  ������� 1���������Լ�����  2��������װ����
            if (eventData.pointerEnter.tag == hero.startdata.equipType)//������װ����
            {
                //ui�������ʾ
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                //gameObject.GetComponent<Bagitem>().ClearData();�������ݳ�������
                //������װ����  ����Ҫͬ��
                hero.RemoveBagData(hero.startdata.id);//�����Ƴ�
                
                hero.AddDicequip();//װ�������
                
            }
            else if (eventData.pointerEnter.tag == "����")//�����ڲ�����
            {
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().ClearData();
            }
            else
            {
                MessageManager.Instance.OnDisPatch(111, "��ʾ", "װ�����Ͳ���", 1);
                UIManager.Instance.OpenUI(PanelName.TipsPanel);
            }
        }
        else//�������ݽ���
        {
            //  ������� 1���������Լ�����  2��������װ����
            if (eventData.pointerEnter.tag == hero.startdata.equipType)//������װ����
            {
                //ui�������ʾ
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().InitData(hero.enddata);
                //������װ����  ����Ҫͬ��
                hero.ChangeDicequip(hero.startdata,hero.enddata);
            }
            else if (eventData.pointerEnter.tag == "����")//�����ڲ�����
            {
                eventData.pointerEnter.GetComponent<Bagitem>().InitData(hero.startdata);
                gameObject.GetComponent<Bagitem>().InitData(hero.enddata);
                
                //hero.SumAllData();
            }
            else
            {
                MessageManager.Instance.OnDisPatch(111, "��ʾ", "װ�����Ͳ���", 1);
                UIManager.Instance.OpenUI(PanelName.TipsPanel);
                Debug.Log("װ�����Ͳ���");
            }
        }
        Destroy(tempdrag);
    }
}
