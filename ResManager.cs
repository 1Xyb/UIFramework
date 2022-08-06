using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;//引入命名空间

public enum FileName//文件名字
{
    icon,UIPanel,UIitem,config,temp
}

/// <summary>
/// 资源管理类
/// </summary>
public class ResManager : Singleton<ResManager>
{
    Dictionary<string, Object> resdic = new Dictionary<string, Object>();//容器  string 资源名字/路径
   /// <summary>
   /// 自己封装的加载资源的方式
   /// </summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="path"></param>
   /// <returns></returns>
    public T Load<T>(string path) where T : Object
    {
        if (resdic.ContainsKey(path))
        {
            return resdic[path] as T;
        }
        else
        {
            T t = Resources.Load<T>(path);
            resdic.Add(path, t);
            return t;
        }
    }
    //重载加载资源的方式
    public T Load<T>(FileName name,string path) where T : Object
    {
        StringBuilder stb = new StringBuilder();
        stb.Append(name + "/" + path);//拼接路径  文件夹名字+路径
        return Load<T>(stb.ToString());
    }
    /// <summary>
    /// 释放资源的方法
    /// </summary>
    public void UnLoad()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
