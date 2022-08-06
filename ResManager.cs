using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;//���������ռ�

public enum FileName//�ļ�����
{
    icon,UIPanel,UIitem,config,temp
}

/// <summary>
/// ��Դ������
/// </summary>
public class ResManager : Singleton<ResManager>
{
    Dictionary<string, Object> resdic = new Dictionary<string, Object>();//����  string ��Դ����/·��
   /// <summary>
   /// �Լ���װ�ļ�����Դ�ķ�ʽ
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
    //���ؼ�����Դ�ķ�ʽ
    public T Load<T>(FileName name,string path) where T : Object
    {
        StringBuilder stb = new StringBuilder();
        stb.Append(name + "/" + path);//ƴ��·��  �ļ�������+·��
        return Load<T>(stb.ToString());
    }
    /// <summary>
    /// �ͷ���Դ�ķ���
    /// </summary>
    public void UnLoad()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
