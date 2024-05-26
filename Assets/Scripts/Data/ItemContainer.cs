using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;

    public void copy(ItemSlot slot)
    {
        item = slot.item;
        count = slot.count;
    }
    public void set(Item item, int count)
    {
        this.item = item;
        this.count = count;

    }
    public void clear()
    {
        item = null;
        count = 0;
    }
}
[CreateAssetMenu(menuName = "Data/ItemContainer")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;
    public void Add(Item item, int Count = 1)
    {
        if(item.Stackable == true)
        {
            ItemSlot itemslot = slots.Find(x => x.item == item);
            if(itemslot != null)
            {
                itemslot.count += Count;
            }
            else
            {
                itemslot = slots.Find(x => x.item == null);
                if(itemslot != null)
                {
                    itemslot.item = item;
                    itemslot.count = Count;
                }
            }
        }
        else
        {
            //thêm item không thể stack
            ItemSlot itemslot = slots.Find(x => x.item == null);
            if(itemslot != null)
            {
                itemslot.item = item;
            }
        }
    }
}
