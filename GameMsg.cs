using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMsg : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConfigManager.Instance.ParseAllConfig();
        ModelManager.Instance.RegisterAllModel();
        
        UIManager.Instance.OpenUI(PanelName.MainPanel);
        ////�����������
        //for (int i = 0; i < ConfigManager.Instance.configTable_HERO.Table.Count; i++)
        //{
        //    Debug.Log("Ӣ������id:" + ConfigManager.Instance.configTable_HERO.Table[i].id + "name:" + ConfigManager.Instance.configTable_HERO.Table[i].name);
        //}\
        //ShopModel.Instance.InitShopmodel();
        //BagModel.Instance.LoadModel();
        //BagModel.Instance.LoadModel1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
