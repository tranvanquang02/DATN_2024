using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer itemContainer;
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
    private void LateUpdate()
    {
        if (itemContainer.isDirty)
        {
            Show();
            itemContainer.isDirty = false;
        }
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
        for (int i = 0; i < itemContainer.slots.Count && i < Buttons.Count; i++)
        {
            if (itemContainer.slots[i].item == null)
            {
                Buttons[i].clean();
            }
            else
            {
                Buttons[i].Set(itemContainer.slots[i]);
            }
        }
    }
    public virtual void OnClick(int id)
    {

    }
}
