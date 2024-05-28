using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApply(Vector2 worldPoint)
    {
        Debug.LogWarning("On Apply not implment");
        return true;
    }
    public virtual bool OnApplyOnTileMap(Vector3Int gridPos, 
        TileMapManager tileMapManager, Item item)
    {
        return true;
    }
    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {

    }
}
