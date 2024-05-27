using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool Action/Seed") ]
public class SeedTile : ToolAction
{
    public override bool OnApplyOnTileMap(Vector3Int gridPos, TileMapManager tileMapManager)
    {
        if(tileMapManager.cropManager.check(gridPos) == false) return false;

        tileMapManager.cropManager.seed(gridPos);
        return true;
    }
    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);
    }
}
