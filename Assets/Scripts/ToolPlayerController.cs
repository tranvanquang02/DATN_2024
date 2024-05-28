using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolPlayerController : MonoBehaviour
{
    private PlayerController player;
    private Rigidbody2D rb;
    private Animator animator;
    private ToolbarController toolbarController;
    [SerializeField] float OffsetDistance = 1.0f;
    [SerializeField] float SizeOfInteracableArea = 1.5f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapManager tileMapManager;

    //[SerializeField] TileData PlowableTiles;

    [SerializeField] float MaxDistance = 1.5f;
    Vector3Int SelectedTilePosition;
    bool Selectable;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
        animator = GetComponent<Animator>();
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
    //dụng cụ tương tác với cây, đá,.. nhưng không phải tile map
    private bool UseToolworld()
    {
        Vector2 position = rb.position + player.LastMotionVector * OffsetDistance;
        Item item = toolbarController.GetItem;
        if(item == null) { return false; }
        if(item.OnAction == null) { return false; }
        animator.SetTrigger("act");
        bool complete = item.OnAction.OnApply(position);
        if (complete == true)
        {
            if (item.OnItemUsed != null)
                item.OnItemUsed.OnItemUsed(item, GameManager.Instance.Inventory);
        }
        return complete;
    }
    //dụng cụ tương tác với tile map
    private void UseToolGrid()
    {
        if (Selectable == true)
        {
            Item item = toolbarController.GetItem;
            if (item == null) { return; }
            if (item.OnTileMapAction == null) { return; }

            bool complete = item.OnTileMapAction.OnApplyOnTileMap(
                SelectedTilePosition, 
                tileMapManager, 
                item);
            if (complete == true) {
                if(item.OnItemUsed != null)
                    item.OnItemUsed.OnItemUsed(item, GameManager.Instance.Inventory);
            }
        }
    }
}
