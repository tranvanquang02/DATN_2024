using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot_UI : MonoBehaviour
{
    [SerializeField]public Image m_itemIcon;
    [SerializeField]public TextMeshProUGUI m_quantitytxt;

    public void setItem(Inventory.slot slot)
    {
        if(slot != null)
        {
            m_itemIcon.sprite = slot.m_icon;
            m_itemIcon.color = new Color(1,1,1,1);
            m_quantitytxt.text = slot.m_Count.ToString();
        }
    }
    public void setEmpty()
    {
        m_itemIcon.sprite = null;
        m_itemIcon.color = new Color(1, 1, 1, 0);
        m_quantitytxt.text = "";
    }
}
