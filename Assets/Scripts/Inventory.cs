using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
  public List<slot> slots = new List<slot>();
  [System.Serializable]
  public class slot
    {
        public int m_Count;
        public int m_maxtAllowed;
        public CollectableType m_type;
        public Sprite m_icon; 

        public slot()
        {
            m_Count = 0;
            this.m_maxtAllowed = 99;
            m_type = CollectableType.none;
        }
        public bool canAddItem()
        {
            if (m_Count < m_maxtAllowed)
                return true;
            return false;
        }
        public void AddItem(Collectable item)
        {
            this.m_type = item.m_type;
            this.m_icon = item.m_icon;
            m_Count++;
        }
        public void RemoveItem()
        {
            if(m_Count > 0)
            {
                m_Count--;
                if(m_Count == 0)
                {
                    m_type = CollectableType.none;
                    m_icon = null;
                }
            }
        }
    }

    public Inventory(int slotNumbers)
    {
        for (int i = 0; i < slotNumbers; i++)
        {
            slots.Add(new slot());
        }
    }
    public void Add(Collectable item)
    {
        foreach (slot slot in slots)
        {
            if (slot.m_type == item.m_type && slot.canAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }
        foreach (slot slot in slots)
        {
            if(slot.m_type == CollectableType.none)
            {
                slot.AddItem(item);
                return;
            }
                

        }
    }
    public void remove(int index)
    {
        slots[index].RemoveItem();
    }

}
