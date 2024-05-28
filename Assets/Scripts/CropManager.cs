using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class CropTile
{
    public int GrowTimer;
    public Crop crop;
    public int GrowStage;
    public SpriteRenderer spriteRenderer;
}
public class CropManager : TimeAgent
{
    [SerializeField] TileBase Plowed;
    [SerializeField] TileBase Seeded;
    [SerializeField] Tilemap TargetTilemap;
    [SerializeField] GameObject CropsSpriteprefab;
    Dictionary<Vector2Int, CropTile> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, CropTile>();
        OnTimeTick += Tick;
        Init();
    }
    public void Tick()
    {
        foreach (CropTile cropTile in crops.Values)
        {
            if(cropTile.crop == null) continue;
            cropTile.GrowTimer += 1;
            if(cropTile.GrowTimer >= cropTile.crop.GrowStageTime[cropTile.GrowStage])
            {
                cropTile.spriteRenderer.gameObject.SetActive(true);
                cropTile.spriteRenderer.sprite = cropTile.crop.sprites[cropTile.GrowStage];
                cropTile.GrowStage += 1;
            }
            if(cropTile.GrowTimer >= cropTile.crop.TimeToGrow)
            {
                Debug.Log("I an done growing");
                cropTile.crop = null;
            }
        }
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
    public void seed(Vector3Int position, Crop toSeed) 
    {
        TargetTilemap.SetTile(position, Seeded);

        crops[(Vector2Int)position].crop = toSeed;
    }
    private void CreatPlowedTile(Vector3Int position)
    {
        CropTile crop = new CropTile();
        crops.Add((Vector2Int)position, crop);

        GameObject go = Instantiate(CropsSpriteprefab);
        go.transform.position = TargetTilemap.CellToWorld(position);
        go.transform.position -= Vector3.forward * 0.01f;

        go.SetActive(false);
        crop.spriteRenderer = go.GetComponent<SpriteRenderer>();
        TargetTilemap.SetTile(position, Plowed);
    }
}
