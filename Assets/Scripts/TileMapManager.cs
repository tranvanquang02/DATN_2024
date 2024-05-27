using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{

    [SerializeField] Tilemap tilemap;
    public CropManager cropManager;

    public Vector3Int GetGridPosition(Vector2 pos, bool mousePositon = false) 
    {
        Vector3 WorldPosition;
        if (mousePositon)
        {
            WorldPosition = Camera.main.ScreenToWorldPoint(pos);

        }
        else
        {
            WorldPosition = pos;
        }

        Vector3Int gridPositon = tilemap.WorldToCell(WorldPosition);

        return gridPositon;
    }
    public TileBase GetTileBase(Vector3Int gridPositon )
    {

        TileBase tile = tilemap.GetTile(gridPositon);

        return tile;
    }
 
}
