using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTilemap;
    [SerializeField] TileBase tile;

    public Vector3Int markedCellPosition;
    Vector3Int oldCellPositon;

    private void Update()
    {
        targetTilemap.SetTile(oldCellPositon, null);
        targetTilemap.SetTile(markedCellPosition, tile);
        oldCellPositon = markedCellPosition;
    }
}
