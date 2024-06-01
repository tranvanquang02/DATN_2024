using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tool Action/Harvest")]
public class TilePickUpAction : ToolAction
{
    public override bool OnApplyOnTileMap(Vector3Int gridPos, TileMapManager tileMapManager, Item item)
    {
       tileMapManager.cropManager.PickUp(gridPos);

        return true;
    }
}
