using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/TileData")]
public class TileData : ScriptableObject
{
    public bool Plowable;

    public List<TileBase> Tiles;
}
