using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理所有数据模型
public class ModelManager : Singleton<ModelManager>
{
    //管理所有数据的容器     Type 相当于数据类的脚本名字
    Dictionary<Type, Modelbase> modeldic = new Dictionary<Type, Modelbase>();
    
    //注册所有数据    公开 供游戏入口使用
    public void RegisterAllModel()
    {
        Register(new ShopModel());
        Register(new BagModel());
        Register(new HeroModel());
        Register(new PmModel1());

    }
    /// <summary>
    /// 注册单个数据模型
    /// </summary>
    /// <param name="model">你注册的数据</param>
    private void Register(Modelbase model)
    {
        if (!modeldic.ContainsKey(model.GetType()))
        {
            modeldic.Add(model.GetType(), model);
            //初始化
            model.LoadModel();
        }
    }
    /// <summary>
    /// 封装的对外提供的使用对应数据模型的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T getmodel<T>() where T : Modelbase
    {
        if (modeldic.ContainsKey(typeof(T)))
        {
            return modeldic[typeof(T)] as T;
        }
        else
        {
            Debug.Log("没有注册对应的类" + typeof(T));
            return null;
        }
    }
}
