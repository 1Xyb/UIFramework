using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ͼ���
/// </summary>
public class ConfigTable<T>where T : ConfigBase
{
    public List<T> Table = new List<T>();
}
