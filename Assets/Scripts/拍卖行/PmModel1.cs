using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmModel1 : Modelbase
{
    public List<Inventory> pmlist;
    public List<Inventory> headlist = new List<Inventory>();
    public List<Inventory> yflist = new List<Inventory>();
    public List<Inventory> xzlist = new List<Inventory>();
    public override void LoadModel()
    {
        pmlist = new List<Inventory>();
        for (int i = 0; i < ConfigManager.Instance.configTable_Inventory.Table.Count; i++)
        {
            pmlist.Add(ConfigManager.Instance.configTable_Inventory.Table[i]);
        }
        headlist = pmlist.FindAll((a) => { if (a.equipType == "Í·²¿") { return true; } else return false; });
        Debug.LogWarning(headlist.Count);
        base.LoadModel();
    }
}
