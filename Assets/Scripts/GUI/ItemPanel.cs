using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer Inventory;
    public List<InventoryButton> Buttons;

    private void OnEnable()
    {
        Show();
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        SetIndex();
        Show();
    }
    private void SetIndex()
    {
        for (int i = 0;  i < Buttons.Count; i++)
        {
            Buttons[i].SetIndex(i);
        }
    }

    public virtual void Show()
    {
        for (int i = 0; i < Inventory.slots.Count && i < Buttons.Count; i++)
        {
            if (Inventory.slots[i].item == null)
            {
                Buttons[i].clean();
            }
            else
            {
                Buttons[i].Set(Inventory.slots[i]);
            }
        }
    }
    public virtual void OnClick(int id)
    {

    }
}
