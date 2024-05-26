using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;
    private ToolbarController toolbarController;
    [SerializeField] float OffsetDistance = 1.0f;
    [SerializeField] float SizeOfInteracableArea = 1.5f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapManager tileMapManager;
    [SerializeField] float MaxDistance = 1.5f;
    [SerializeField] CropManager cropManager;
    [SerializeField] TileData PlowableTiles;

    Vector3Int SelectedTilePosition;
    bool Selectable;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
    }

    private void Update()
    {
        SelectedTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolworld() == true)
            {
                return;
            }
            
            UseToolGrid();
        }
    }
    private void SelectedTile()
    {
        SelectedTilePosition = tileMapManager.GetGridPosition(Input.mousePosition, true);
    }
    private void Marker()
    {
        markerManager.markedCellPosition = SelectedTilePosition;
    }
    private void CanSelectCheck()
    {
        Vector2 PlayerPosition = transform.position;
        Vector2 CameraPositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Selectable = Vector2.Distance(PlayerPosition, CameraPositon) < MaxDistance;
        markerManager.Show(Selectable);
    }
    private bool UseToolworld()
    {
        Vector2 position = rb.position + player.LastMotionVector * OffsetDistance;
        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if(item.OnAction == null) { return false; }
        
        bool complete = item.OnAction.OnApply(position);
        return complete;
    }
    
    private void UseToolGrid()
    {
        if (Selectable == true)
        {
            TileBase tileBase = tileMapManager.GetTileBase(SelectedTilePosition);
            TileData tileData = tileMapManager.GetTileData(tileBase); 
            if (tileData != PlowableTiles) { return; }
            if (cropManager.check(SelectedTilePosition))
            {
                cropManager.seed(SelectedTilePosition);
            }
            else
            {
                cropManager.plow(SelectedTilePosition);
            }
            
        }
    }
}
