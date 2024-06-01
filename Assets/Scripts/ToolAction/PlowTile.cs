using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Data/Tool Action/Plow")]
public class PlowTile : ToolAction
{
    [SerializeField] List<TileBase> canPlow ;

    public override bool OnApplyOnTileMap(Vector3Int gridPos,
        TileMapManager tileMapManager, Item item)
    {
        TileBase tileToPlow = tileMapManager.GetTileBase(gridPos);

        if(canPlow.Contains(tileToPlow) == false) 
        {
            return false;
        }
        tileMapManager.cropManager.Plow(gridPos);

        return true;
    }
}
