using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������������ģ��
public class ModelManager : Singleton<ModelManager>
{
    //�����������ݵ�����     Type �൱��������Ľű�����
    Dictionary<Type, Modelbase> modeldic = new Dictionary<Type, Modelbase>();
    
    //ע����������    ���� ����Ϸ���ʹ��
    public void RegisterAllModel()
    {
        Register(new ShopModel());
        Register(new BagModel());
        Register(new HeroModel());
        Register(new PmModel1());

    }
    /// <summary>
    /// ע�ᵥ������ģ��
    /// </summary>
    /// <param name="model">��ע�������</param>
    private void Register(Modelbase model)
    {
        if (!modeldic.ContainsKey(model.GetType()))
        {
            modeldic.Add(model.GetType(), model);
            //��ʼ��
            model.LoadModel();
        }
    }
    /// <summary>
    /// ��װ�Ķ����ṩ��ʹ�ö�Ӧ����ģ�͵ķ���
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
            Debug.Log("û��ע���Ӧ����" + typeof(T));
            return null;
        }
    }
}
