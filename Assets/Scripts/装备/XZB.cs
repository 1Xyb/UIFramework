using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XZB : MonoBehaviour, IPointerDownHandler
{
    HeroModel hero;
    public void OnPointerDown(PointerEventData eventData)
    {
        hero.xzdata = eventData.pointerEnter.GetComponent<Bagitem>().xzdata;
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Bagitem>().ClearData();
            HeroPanel.allbox[hero.bagList.Count].GetComponent<Bagitem>().InitData(hero.xzdata);
            hero.AddBag(hero.xzdata);
            hero.RemoveDicequip();
        }
    }
    private void Start()
    {
        hero = ModelManager.Instance.getmodel<HeroModel>();
    }
}
