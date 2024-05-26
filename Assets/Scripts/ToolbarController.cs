using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] int ToolbarSize = 12;
    int SelectedTool;

    public Action<int> OnChange;
    internal void set(int id)
    {
        SelectedTool = id;
    }
    public Item GetItem
    {
        get
        {
            return GameManager.Instance.Inventory.slots[SelectedTool].item;
        }
    }
    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if(delta != 0)
        {
            if(delta > 0 )
            {
                SelectedTool += 1;
                SelectedTool = (SelectedTool >= ToolbarSize) ? 0 : SelectedTool;
            }
            else
            {
                SelectedTool -= 1;
                SelectedTool = (SelectedTool <= 0) ? ToolbarSize - 1 : SelectedTool;
            }
            OnChange?.Invoke(SelectedTool);
        }
    }

}
