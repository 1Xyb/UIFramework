using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbase : MonoBehaviour
{
    public PanelType type;
    public virtual void Init() { }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
