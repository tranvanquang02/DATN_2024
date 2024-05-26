using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Crops
{

}
public class CropManager : MonoBehaviour
{
    [SerializeField] TileBase Plowed;
    [SerializeField] TileBase Seeded;
    [SerializeField] Tilemap TargetTilemap;

    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }
    public bool check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }
    public void plow(Vector3Int position)
    {
        if(crops.ContainsKey((Vector2Int)position))
        {
            return;
        }
        CreatPlowedTile(position);
    }
    public void seed(Vector3Int position)
    {
        TargetTilemap.SetTile(position, Seeded);
    }
    private void CreatPlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);
        TargetTilemap.SetTile(position, Plowed);
    }
}
